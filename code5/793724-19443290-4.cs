    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.NavigationMode == NavigationMode.Back)
        {
            String pageType = null;
            NavigationContext.QueryString.TryGetValue("PAGE_TYPE", out pageType);
            if (pageType == "Page1")
            {
                //Your code
            }
        }
    }
