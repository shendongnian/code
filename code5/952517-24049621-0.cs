    public static string Get(string Key)
    {
        Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
        KeyValueConfigurationCollection settings = config.AppSettings.Settings;
        if (settings[Key] != null)
            return settings[Key].Value;
        else
            return "";
    }
