    // Code to execute when the application is deactivated (sent to background)
    // This code will not execute when the application is closing
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        settings["Url"] = Url;
        settings.Save();
    }
    // Code to execute when the application is closing (eg, user hit Back)
    // This code will not execute when the application is deactivated
    private void Application_Closing(object sender, ClosingEventArgs e)
    {
        IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
        settings["Url"] = Url;
        settings.Save();
    }
