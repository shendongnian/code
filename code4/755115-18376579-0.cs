    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (this.NavigationContext.QueryString.ContainsKey("param1"))
        {
            string param = this.NavigationContext.QueryString["Param"]; //Get "Param" this QueryString. 
            // .. Do Stuff
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            NavigationService.RemoveBackEntry();
        }
    }
