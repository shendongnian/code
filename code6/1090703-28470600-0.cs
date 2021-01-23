    class Program
    {
        static void Main(string[] args)
        {
            UpdateSetting("language", "English");
        }
    
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
    
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
