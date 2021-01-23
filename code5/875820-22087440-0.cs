    WebClient webClient = new WebClient();
                
    webClient.DownloadProgressChanged += OnChange;
    webClient.DownloadFileCompleted += OnCompleted;
    webClient.DownloadFileAsync(new Uri(download), fileAndPath);
