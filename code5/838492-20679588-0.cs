    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
            Application.Current.Terminate();
    
        base.OnNavigatedTo(e);
    }
