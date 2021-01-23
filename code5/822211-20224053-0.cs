    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (NavigationContext.QueryString.ContainsKey("key"))
        {
             string key = NavigationContext.QueryString["key"];
             // etc ...
        }
    }
