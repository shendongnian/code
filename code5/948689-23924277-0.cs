    // Copy user settings from previous application version if necessary
    if (MyApp.Properties.Settings.Default.UpdateSettings)
    {
        MyApp.Properties.Settings.Default.Upgrade();
        MyApp.Properties.Settings.Default.UpdateSettings = false;
        MyApp.Properties.Settings.Default.Save();
    }
