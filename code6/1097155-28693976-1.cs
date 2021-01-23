    private bool APP_VISIBLE = true;
    protected override async void OnLaunched(LaunchActivatedEventArgs e)
    {
        // Stuff put here by Visual Studio
        
        Window.Current.VisibilityChanged += OnVisibilityChanged;
        Window.Current.Activate();
    }
    private void OnVisibilityChanged(object sender, VisibilityChangedEventArgs e)
    {
        if (e.Visible)
            APP_VISIBLE = true;
        else
            APP_VISIBLE = false;
    }
