        foreach (var uri in myCollection)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (System.Net.WebClient client = new System.Net.WebClient())
                    {
                        client.DownloadDataCompleted += (o, args) =>
                        {
                            //Do something with the download
                        };
                        client.DownloadDataAsync(uri);
                    }
                }
                catch (Exception ex)
                {
                    //Do something
                }
            });
        }
