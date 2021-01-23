    public static async Task<bool> SmallUpload1(string ftpURIInfo, string filename, string username, string password)
        {
            string serverUrl;
            Uri serverUri = null;
            //StorageFolder localFolderArea;
            NetworkCredential credential;
            bool Successful = false;
            try
            {
                StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                StorageFile targetFile = await storageFolder.GetFileAsync("wp_ss_20150313_0001.png");
                Uri.TryCreate(ftpURIInfo, UriKind.Absolute, out serverUri);
                serverUrl = serverUri.ToString();
                credential = new System.Net.NetworkCredential(username.Trim(),
                    password.Trim());
                WebRequest request = WebRequest.Create(serverUrl + "/" + filename);
                request.Credentials = credential;
                request.Proxy = WebRequest.DefaultWebProxy;
                //STOR is for ftp: // POST is for http:// web sites
                request.Method = "STOR";
                byte[] buffer = Encoding.UTF8.GetBytes(UploadLine);
                
                using (Stream requestStream = await request.GetRequestStreamAsync())
                {
                    using (var stream = await targetFile.OpenStreamForReadAsync())
                    {
                        stream.CopyTo(requestStream);
                    }
                }
                Successful = true;
            }
            catch (Exception)
            {
                throw;
            }
            return Successful;
        } 
