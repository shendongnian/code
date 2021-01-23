    private async Task Download(string p_Version)
    {
      string file = p_Version + ".zip";
      string url = @"http://192.168.56.5/" + file;
    
      //client is global in the class
      client = new WebClient();
      client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
      client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
      await client.DownloadFileAsync(new Uri(url), @"C:\tmp\" + file);
    }
