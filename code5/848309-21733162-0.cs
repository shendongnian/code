    public static void ClearUserConfigFile()
    {
        //Touch each setting
        foreach (SettingsProperty property in Settings.Default.Properties)
        {
            if (property.DefaultValue != Settings.Default[property.Name])
                Settings.Default[property.Name] = Settings.Default[property.Name];
        }
    
        //Delete the user.config file
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
        var userConfigPath = config.FilePath;
        try
        {
            if (File.Exists(userConfigPath) == true)
                File.Delete(userConfigPath);
        }
        catch (Exception ex)
        {
            _log.ErrorFormat("Exception thrown while deleting user.config : {0}", ex.ToString());
        }
    }
