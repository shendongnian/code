        void Upload(string ftpServer, string userName, string password, string filename)
        {
            using(var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(userName, password);
                client.UploadFile(new Uri(ftpServer + "/" + new FileInfo(filename).Name), "STOR", filename);
            }
        }
