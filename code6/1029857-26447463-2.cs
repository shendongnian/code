        private static void UpdateKey(string newValue)
        {
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = ConfigurationManager.AppSettings["configPath"];
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            config.AppSettings.Settings["password"].Value = newValue;
            config.Save();
        }
