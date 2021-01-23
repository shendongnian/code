        foreach (var uri in myCollection)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        client.DownloadFileCompleted += (o, args) =>
                        {
                            //Do something with the download
                        };
                        client.DownloadFileAsync(uri);
                    }
                }
                catch (Exception ex)
                {
                    //Do something
                }
            });
        }
