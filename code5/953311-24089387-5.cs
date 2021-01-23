    private async void loginBtn_Click(object sender, RoutedEventArgs e)
    {
        WCFserviceReference.WCFserviceClient proxy = new WCFserviceReference.WCFserviceClient();
        bool returnStr = await proxy.loginAsync(passTxtBx.Text, loginTxtBx.Text);
        if (returnStr == true)
        {
            PhoneApplicationService.Current.State["UserName"] = loginTxtBx.Text;
            NavigationService.Navigate(new Uri("/Pages/usrPage.xaml", UriKind.RelativeOrAbsolute));
        }
        else MessageBox.Show("Invalid user credentials");
    }
