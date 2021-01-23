    public Task<bool> IsAuthenticatedAsync(string _userName, string _password)
    {
        return (bool) (_isAuthenticated ?? (_isAuthenticated = await AuthenticateAsync(_userName, _password)));
    }
    private async void BtnLogin_OnClick(object sender, RoutedEventArgs e)
    {
        var user = new User();
        if (await user.IsAuthenticatedAsync(tbUserName.Text, tbPassword.Text))
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml"));
        }
    }
