    exePath = Path.Combine( exePath, "MyApp.exe" );
        Configuration config = ConfigurationManager.OpenExeConfiguration( exePath );
        var setting = config.AppSettings.Settings[SettingKey];
        if (setting != null)
        {
            setting.Value = newValue;
        }
        else
        {
            config.AppSettings.Settings.Add( SettingKey, newValue);
        }
    
        config.Save();
