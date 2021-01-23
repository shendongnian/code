    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e); 
        string parameterValue = string.Empty; 
         parameterValue = NavigationContext.QueryString["anim"];  
    }
