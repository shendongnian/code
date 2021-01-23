      private void LinkClicked(object sender, System.Windows.Input.GestureEventArgs e)
        {
                        
                  
                            string url = "http://google.com";
                            WebBrowserTask wbt = new WebBrowserTask();
                            wbt.Uri = new Uri(url);
                            wbt.Show();
            }
