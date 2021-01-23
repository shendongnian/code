    public static class SettingsFactory
    {
        private const string Key = "Application.Settings";
        public static ApplicationSettings Settings
        {
            get
            {
                if (HttpContext.Current.Application[Key] == null)
                {
                    HttpContext.Current.Application[Key] = LoadSettings();
                }
                return HttpContext.Current.Application[Key] as ApplicationSettings;
            }
        }
        public static ApplicationSettings LoadSettings()
        {
            // Return/create instance of your application settings from your database.
            return new ApplicationSettings();
        }
    }
    [Serializable]
    public class ApplicationSettings
    {
        public string ApplicationName { get; set; }
        public string ApiKey { get; set; }
    }
