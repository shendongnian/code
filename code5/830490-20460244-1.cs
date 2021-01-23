    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        using (var folder = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (folder.FileExists("SomeFileWithToken.txt"))
            {
                RootFrame.Navigate(new Uri("/ProfilePage.xaml", UriKind.Relative));
            }
            else
            {
                RootFrame.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
            }
    
        }
    }
