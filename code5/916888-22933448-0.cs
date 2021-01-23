    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        String parameter = NavigationContext.QueryString["QueryStringParameter"];
 
        // OR
        string param;
        if (NavigationContext.QueryString.TryGetValue(
            "QueryStringParameter", out param)
        {
            // a parameter exists. work with the value
        }
    }
