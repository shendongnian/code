    public void SetLoginStatus( bool loggedIn )
    {
        if(loggedIn)
        {
            MainPage.SettingsPage.Visibility = Visibility.Visible;
        }
        else
        {
            MainPage.SettingsPage.Visibility = Visibility.Collapsed;
        }
    }
