    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (NavigationContext.QueryString.ContainsKey("key"))
        {
             string val = NavigationContext.QueryString["key"];
        }
    }
