    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);            
        string clearParam;
        if (NavigationContext.QueryString.TryGetValue("clear", out clearParam))
        {
            if (Convert.ToBoolean(clearParam))
            {
                // Delete "Add New Item" from the navigation stack
                NavigationService.RemoveBackEntry();
            }
        }
    }
