    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Extensions.Configuration;
    using System;
    public class MyClass {
        public string GetEmailAddress() {
            //For example purpose only, try to move this to a right place like configuration manager class
            string basePath= System.AppContext.BaseDirectory;
            IConfigurationRoot configuration= new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("config.json")
                .Build();
            return configuration.Get("emailAddress");
        }
    }
