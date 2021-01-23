        private class MyConfig : cherry.Framework.IConfigurationReader
        {
            private String ConfigFile { get; set; }  
            
            public MyConfig(String configFile)
            {
                ConfigFile = configFile;
            }
            public string GetConfigSetting(string settingName)
            {
                var setting  = XDocument.Load(ConfigFile).Descendants("add").Select(s => new
                {
                    AppKey = s.Attribute("key"),
                    AppValue = s.Attribute("value")
                }).FirstOrDefault(x => x.AppKey.Value == settingName);
                if (setting == null)
                {
                    throw new Exception("key not found!");
                }
                else
                    return setting.AppValue.Value;
            }
        }
