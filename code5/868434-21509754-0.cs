    static class Configuration
    {
        private static AppSettingsSection _appSettingsLogsSection;
        public static int LogSendIntervalMinutes { get; private set; }
        static Configuration()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _appSettingsLogsSection = config.GetSectionGroup("Logs").Sections["appSettings"] as AppSettingsSection;
            LogSendIntervalMinutes = Convert.ToInt32(_appSettingsLogsSection.Settings["LogSendIntervalMinutes"]);
        }
    }
