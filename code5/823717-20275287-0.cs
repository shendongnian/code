    var settings = ConfigurationManager.AppSettings;
    for (int i = 0; i < settings.Count; i++)
    {
        categories.Add(settings[i]);
    }
