    private void InitializeWebClient()
    {
        _webClient = new WebClient();
        _webClient.DownloadFileCompleted += DownloadCompletedCallback;
        _webClient.DownloadProgressChanged += DownloadProgressCallback;
    }
