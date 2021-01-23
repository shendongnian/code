    public void UpdateKeyValue(string propertyName, object newValue)
    {
        Configuration config = 
            WebConfigurationManager
                .OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        config.AppSettings.Settings.Remove(propertyName);
        config.AppSettings.Settings.Add(propertyName, newValue.ToString());
        config.Save();
    }
