    private void btnDownload_Click(object sender, EventArgs e)
    {
      WebClient webClient = new WebClient();
      webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
      webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
      webClient.DownloadFileAsync(new Uri("pdf file address"), @"c:\myfile.pdf");
    }
    
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      progressBar.Value = e.ProgressPercentage;
    }
    
    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
      MessageBox.Show("Download completed!");
    }
