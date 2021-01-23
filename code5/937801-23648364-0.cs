    private async Task Authenticate()
    {
        string message = String.Empty;
        try
        {
            session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream,publish_actions");
            App.AccessToken = session.AccessToken;
            App.FacebookId = session.FacebookId;
    
            Dispatcher.BeginInvoke(() => NavigationService.Navigate(new Uri("/Pages/LandingPage.xaml", UriKind.Relative)));
        }
        catch (InvalidOperationException e)
        {
            message = "Login failed! Exception details: " + e.Message;
            MessageBox.Show(message);
        }
    }
