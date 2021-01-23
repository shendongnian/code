     private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            try
            {
                Object signedinflag = IsolatedStorageSettings.ApplicationSettings["userSignedIn"];
                if (signedinflag.ToString() == "True")
                {
                    RootFrame.Navigate(new Uri("/dashboard.xaml", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }
