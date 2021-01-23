    public static void CreateOtherAppSettings()
    {
        Configuration config =
            ConfigurationManager.OpenExeConfiguration("OtherApp.config");
            
        config.AppSettings.Settings.Add("ClientID", "456");
        config.AppSettings.Settings.Add("ApiUrl", "http://some.other.api/url");
        config.Save(ConfigurationSaveMode.Modified);
    }
