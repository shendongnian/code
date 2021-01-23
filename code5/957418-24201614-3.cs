    void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if (e.Uri.ToString().Contains("Login.xaml"))
        {
           if (userIsValid)
           {
                 e.Cancel = true; //cancel it.
                 string uriString = "/MainPage.xaml";
                 var ur = new Uri(uriString, UriKind.Relative);
                 RootFrame.Dispatcher.BeginInvoke(delegate
                 {
                     this.RootFrame.Navigate(ur);
                 });
            }
        }
    }
