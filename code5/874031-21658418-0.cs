    // in constructor
    ApplicationBar.StateChanged+=ApplicationBar_StateChanged;
    private void ApplicationBar_StateChanged(object sender, ApplicationBarStateChangedEventArgs e)
    {
            if (e.IsMenuVisible) ApplicationBar.Opacity = 1;
            else ApplicationBar.Opacity = 0;
    }
    
