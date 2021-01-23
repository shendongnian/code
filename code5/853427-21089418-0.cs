        public string FileLocation
        {
            get { return Configuration.FilePath; }
        }
        private static Configuration Configuration
        {
            get { return OpenConfig(ConfigurationUserLevel.PerUserRoamingAndLocal); }
        }
        private static Configuration OpenConfig(ConfigurationUserLevel userLevel)
        {
            return ConfigurationManager.OpenExeConfiguration(userLevel);
        }
