    private void Function()
            {
                    string url = String.Format("**your xaml string here**");
                    try
                    {
                        destination = null;
                        WebClient webClient = new WebClient();
                        webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(EndFunction);
                        webClient.DownloadStringAsync(new Uri(url));
                    }
                    catch
                    {
                        ///todo: criar if para verificar conexão   
                        MessageBox.Show("Verify your connection and try again!");
                    }
            }
     private void EndFunction(object sender, DownloadStringCompletedEventArgs e)
            {            
                if (e.Error != null)
                {
                    MessageBox.Show("Verify your connection and try again!");
                }
                else
                {
                    // Save the feed into the State property in case the application is tombstoned. 
                    this.State["xml"] = e.Result;
                    x = ParserXML(e.Result);                
                }
            }
