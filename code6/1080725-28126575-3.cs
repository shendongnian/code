    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        var navigableViewModel = this.DataContext as INavigable;
        if (navigableViewModel != null)
        {
            if (e.NavigationMode == NavigationMode.Back && !navigableViewModel.AllowGoBack())
            {
                e.Cancel = true;
            }
        }
    }
