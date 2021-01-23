    public class ConfigurationSettings
    {
        private ConfigurationSettings _instance;
        public int Setting1 { get; set; }
        public static ConfigurationSettings GetInstance()
        {
            return _instance;
        }
        // call this method once to load up all the data (at startup)
        public static void InitializeSingleInstance()
        {
            _instance = new ConfigurationSettings();
        }
        private ConfigurationSettings() 
        {
            // load from db / files / ... 
        }
    }
