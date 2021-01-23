    private bool downloadComplete = false;
    private void startDownload(Uri toDownload, string saveLocation)
    {
        string outputFile = Path.Combine(saveLocation, Path.GetFileName(toDownload.AbsolutePath));
        WebClient client = new WebClient();
        client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
        client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
        client.DownloadFileAsync(toDownload, outputFile);
        while (!downloadComplete)
        {
            Application.DoEvents();
        }
        downloadComplete = false;
    }
    void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
    // No changes in this method...
    }
    void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.BeginInvoke((MethodInvoker)delegate
        {
            textBoxLog.AppendText("OK");
            downloadComplete = true;
        });
    }
