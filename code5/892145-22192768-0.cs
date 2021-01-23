    private void InitializePhoneApplication()
            {
                if (phoneApplicationInitialized)
                    return;
     
                // Create the frame but don't set it as RootVisual yet; this allows the splash
                // screen to remain active until the application is ready to render.
                RootFrame = new PhoneApplicationFrame();
                RootFrame.Navigated += CompleteInitializePhoneApplication;
     
                // Handle navigation failures
                RootFrame.NavigationFailed += RootFrame_NavigationFailed;
     
                // Handle reset requests for clearing the backstack
                RootFrame.Navigated += CheckForResetNavigation;
     
                // Ensure we don't initialize again
                phoneApplicationInitialized = true;
     
                Uri uri;
                if (IsolatedStorageSettings.ApplicationSettings.Contains("islogin"))
                {
                    if (!(Convert.ToString(IsolatedStorageSettings.ApplicationSettings["islogin"]).ToLower() == "yes"))
                    {
                        RootFrame.Navigate(new Uri("/LoginScreen.xaml", UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        RootFrame.Navigate(new Uri("/HomeScreen.xaml", UriKind.RelativeOrAbsolute));               
                    }
                }
                else
                {
                    RootFrame.Navigate(new Uri("/LoginScreen.xaml", UriKind.RelativeOrAbsolute));
                }          
            }
