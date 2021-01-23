    public AppForm() // constructor
    {
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
    }
    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        Debug.Print("Settings changed category: {0}", e.Category);
        CultureInfo.CurrentCulture.ClearCachedData();
        CultureInfo.CurrentUICulture.ClearCachedData();
        Debug.Print("Current Culture: {0}", CultureInfo.CurrentCulture);
        Debug.Print("Current UI Culture: {0}", CultureInfo.CurrentUICulture);
    }
