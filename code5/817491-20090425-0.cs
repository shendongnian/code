     private void btnSignIn_SessionChanged(object sender, Microsoft.Live.Controls.LiveConnectSessionChangedEventArgs e)
            {
                try
                {
    
                    if (e.Session != null && e.Status == LiveConnectSessionStatus.Connected)
                    {
                        client = new LiveConnectClient(e.Session);
                        client.GetCompleted += new EventHandler<LiveOperationCompletedEventArgs>(client_GetCompleted);
                        client.UploadCompleted += new EventHandler<LiveOperationCompletedEventArgs>(client_UploadCompleted);
                        client.GetAsync("me/SkyDrive/files", null);
                        client.DownloadAsync("me/SkyDrive", null);
                        canUpload = true;
                        ls = e.Session;
                     
                    }
                    else
                    {
                        if (client != null)
                        {
                            MessageBox.Show("Signed out successfully!");
                            client.GetCompleted -= client_GetCompleted;
                            client.UploadCompleted -= client_UploadCompleted;
                            canUpload = false;
                        }
                        else
                        {
                            canUpload = false;
                        }
                        client = null;
                        canUpload = false;
                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
    void client_GetCompleted(object sender, LiveOperationCompletedEventArgs e)
            {
                try
                {
                    List<System.Object> listItems = new List<object>();
                    if (e.Result != null)
                    {
                        listItems = e.Result["data"] as List<object>;
                        for (int x = 0; x < listItems.Count(); x++)
                        {
                            Dictionary<string, object> file1 = listItems[x] as Dictionary<string, object>;
                            string fileName = file1["name"].ToString();
                            if (fileName == lstmeasu[0].Title)
                            {
                                folderID = file1["id"].ToString();
                                folderAlredyPresent = true;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error occured in getting skydrive folders, please try again later.");
                }
            }
