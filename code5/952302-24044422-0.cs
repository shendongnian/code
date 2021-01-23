    var settings = ConfigurationManager.GetSection("dataConfiguration");
    var fi = typeof(ConfigurationElement).GetField("_bReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    fi.SetValue(settings, false);
    DatabaseSettings dbSettings = (DatabaseSettings)ConfigurationManager.GetSection("dataConfiguration");
    dbSettings.DefaultDatabase = databseName;
