    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (NavigationContext.QueryString.ContainsKey("myKey"))
        {
             businessnamereturn = NavigationContext.QueryString["myKey"];
             Locationname.Text = businessnamereturn;
        }
    }
