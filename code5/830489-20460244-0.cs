    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
        using (var folder = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (folder.FileExists("SomeFileWithToken.txt"))
            {
                RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                RootFrame.Navigate(new Uri("/SecondPage.xaml", UriKind.Relative));
            }
    
        }
    }
