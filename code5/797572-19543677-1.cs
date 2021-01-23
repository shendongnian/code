    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.Uri.OriginalString.Contains("id"))
        {
            var ID = NavigationContext.QueryString["id"];          
            //this is a parameter from page1 
            // do something
        }
        else   if (e.Uri.OriginalString.Contains("data"))
        {
            var data = NavigationContext.QueryString["data"];          
            //this is a parameter from page2 
            // do something
        }
    }
