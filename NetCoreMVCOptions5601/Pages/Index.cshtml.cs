using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMVCOptions5601.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public string MySection { get; private set; }
        public string MySettingsValue { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            // Directly setting the string object MySection with the returned valued 
            // _configuration.GetValue<string>("MySection:MySectionItem")
            MySection = _configuration.GetValue<string>("MySection:MySectionItem");

            // MySettings Defined below
            var mySettings = new MySettings();

            // Binding the value of the JSON section named MySection
            // with the strongly typed mySettings class
            _configuration.Bind("MySection", mySettings);

            // Now that mySettings has completed a Bind with the MySection 
            // of the appsettings.json, we can attain the value of the strongly 
            // typed class
            MySettingsValue = mySettings.MySectionSecondItem;
        }
    }


    // The Class MySettings defines properties matching the definition
    // of the appsettings.json file's MySection object
    public class MySettings
    {
        public string MyMySectionItem { get; set; }
        public string MySectionSecondItem { get; set; }
    }
}
