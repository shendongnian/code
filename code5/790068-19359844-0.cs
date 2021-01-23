    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        Microsoft.Phone.Controls.TiltEffect.SetIsTiltEnabled(RootFrame, true);
    }
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
        Microsoft.Phone.Controls.TiltEffect.SetIsTiltEnabled(RootFrame, true);
    }
