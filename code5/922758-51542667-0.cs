    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                        ServicePointManager.DefaultConnectionLimit = 9999;
    
                        log.Info("Downloading file");
                        webClient.DownloadFile("https://somesitedomain/somefile.csv", outfile);
                    }
