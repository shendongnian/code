    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (NavigationContext.QueryString.ContainsKey("Businessname"))
        {
             businessnamereturn = NavigationContext.QueryString["Businessname"];
             Locationname.Text = businessnamereturn;
        }
    }
