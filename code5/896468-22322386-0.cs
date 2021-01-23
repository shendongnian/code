    private void Application_Launching(object sender, LaunchingEventArgs e)
            {
                
                if (IsolatedStorageSettings.ApplicationSettings.Contains("Parse.CurrentUser"))
                {
                    NavigationService.Navigate(new Uri("/email.xaml", UriKind.Relative));
                }
            }
