    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
       string maxCount = string.Empty;
       if (NavigationContext.QueryString.TryGetValue("maxcount", out maxCount))
       {
          //parse the int value from the string or whatever you need to do
       }
    }
