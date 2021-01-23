    async void startDownload(string Pacchetto)
    {
        WebClient client = new WebClient();
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
        await client.DownloadFileAsync(new Uri("http://www.example.com/pack/"+ Pacchetto), @".\pack\" + Pacchetto);
    }
