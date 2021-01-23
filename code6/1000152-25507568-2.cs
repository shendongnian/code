    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back)
        {
            if (App.SomeObjectIPreferToShareAcrossApp != null)
            {
                // yay, do something :)
                App.SomeObjectIPreferToShareAcrossApp = null;
            }
        }
    }
