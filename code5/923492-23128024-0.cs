    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
       if (NavigationContext.QueryString.ContainsKey("logedin"))
       {
           NavigationService.RemoveBackEntry();
       }
    }
