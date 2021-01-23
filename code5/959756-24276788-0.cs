    WebClient client = new WebClient();
    client.DownloadProgressChanged += DownloadProgressChangedHandler;
    client.DownloadFileCompleted += DownloadCompletedHandler;
    client.DownloadFileAsync(new Uri(urlToDownload), filename, urlToDownload);
    // ...
    void DownloadProgressChangedHandler(object sender, DownloadProgressChangedEventArgs e)
    {
        string urlToDownload = (string)e.UserState;  // get the URL we're downloading from
        // do whatever
    }
    void DownloadCompletedHandler(object sender, AsyncCompletedEventArgs e)
    {
        string urlToDownload = (string)e.UserState; // get the URL we're downloading from
        // whatever
    }
