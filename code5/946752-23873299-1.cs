    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);   
        string parameter = string.Empty;
        if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
        {
            //do something with the parameter
        }
    }
