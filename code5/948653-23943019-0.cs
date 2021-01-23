    public async Task DownloadFIle(string url, string path, IProgress<int> progress = null)
    {
      using (WebClient client = new WebClient())
      {
        client.DownloadProgressChanged += (s, e) =>
        {
          if (progress != null)
            progress.Report(e.ProgressPercentage);
        };
        await client.DownloadFileTaskAsync(url, path);
      }
    }
