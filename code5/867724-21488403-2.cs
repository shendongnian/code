    private Settings _settings = new Settings();
    private void InitializePhoneApplication()
    {
        RootFrame.Navigated += RootFrame_Navigated;
    }
     
    void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        if (e.Content is IRequiresSettings)
            ((IRequiresSettings)e.Content).Settings = _settings;
    }
    
