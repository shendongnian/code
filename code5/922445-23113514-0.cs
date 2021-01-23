    private static void SaveString(string key, string value)
    {
        Configuration config= ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        config.AppSettings.Settings[key].Value = value;
        config.Save();
        ConfigurationManager.RefreshSection("appSettings");
    }
