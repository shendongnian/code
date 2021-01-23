    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
        var progressIndicator = new ProgressIndicator { Text = "Your title", IsVisible = true };
        SystemTray.SetProgressIndicator(this, progressIndicator);
    }
