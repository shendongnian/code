    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    	if (appSettings["Parse.CurrentUser"] != null)
        {
            MessageBoxResult result = MessageBox.Show("Welcome Back","Welcome",MessageBoxButton.OK);
            this.NavigationService.Navigate(new Uri("/email.xaml", UriKind.RelativeOrAbsolute));
        }
        else
        {
            // show the signup or login screen
        }
    }
