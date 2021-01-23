    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode == NavigationMode.Back && e.IsNavigationInitiator == false)
        {
            txtHeader.Text = DateTime.Now.ToLongTimeString();
        }
    }
