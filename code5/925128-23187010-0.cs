        private void ListFilesOnServer()
        {
                try
                {
             FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings.Get("IncomingFtpPath"));
                    request.Credentials = new NetworkCredential("user", "password");
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    
                    using(StreamReader reader = new StreamReader(response.GetResponseStream())
                    {
                       string line = null;
                       while((line = reader.ReadLine()) != null)
                       {
                        if (System.IO.Path.GetExtension(line) == ".xml")
                        {
                          WaitingListBox.Items.Add(System.IO.Path.GetFileNameWithoutExtension(line));
                        }
                       }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    // throw e
                }
