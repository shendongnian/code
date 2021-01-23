    public class MyClass
    {
        private readonly string _name1 = GetConfigValue("MyName");
        private readonly string _name2 = GetConfigValue("AnotherSetting");
        private static string GetConfigValue(string settingName)
        {
            var setting = ConfigurationManager.AppSettings[settingName];
            if (setting == null)
                throw new Exception(string.Format("The setting {0} is missing.", settingName));
            return setting;
        }
    }
