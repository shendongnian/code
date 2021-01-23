    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    if (!settings.Contains("firstrun"))
    {
        settings.Add("firstrun", "no");
        settings.Add("defaultLocation", "Dulles, VA");
        settings.Add("defaultTest", "Speed Test");
        settings.Save();
    }
