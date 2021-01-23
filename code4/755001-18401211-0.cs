    private void Browser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
            {
                Console.WriteLine("Browser_Navigated:" + sender);
    
                String currentURL = "";
                Boolean isAbsolute = this.CordovaView.Browser.Source.IsAbsoluteUri;
                ApplicationBar = new ApplicationBar();
                ApplicationBar.Mode =ApplicationBarMode.Minimized;
                if (isAbsolute)
                {
                    currentURL = this.CordovaView.Browser.Source.AbsoluteUri;
    
                    
    
                    ApplicationBarMenuItem clearCache = new ApplicationBarMenuItem();
                    clearCache.Text = "Reset user settings";
                    ApplicationBar.MenuItems.Add(clearCache);
                    clearCache.Click += new EventHandler(OnClearCache);
    
                    if (! currentURL.EndsWith("LoginSP.aspx")) 
                    {
                        ApplicationBarMenuItem logOut = new ApplicationBarMenuItem();
                        logOut.Text = "Log out";
                        ApplicationBar.MenuItems.Add(logOut);
                        logOut.Click += new EventHandler(OnLogOut);
                    }
                }
                else
                {
                    currentURL = "x-wmapp1:" + this.CordovaView.Browser.Source.OriginalString;
                    ApplicationBar.IsVisible = false;
                }
    
                Console.WriteLine("currentURL:" + currentURL);
            }
