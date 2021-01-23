    public async void btnDownload2_Click()
    {
      try
      {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(new Uri("http://somelink/video/nameOfFile.mp4"), HttpCompletionOption.ResponseHeadersRead);
    
        response.EnsureSuccessStatusCode();
    
        using(var isolatedStorageFile = IsolatedStorageFile.GetUserStoreForApplication())
        {
          bool checkQuotaIncrease = IncreaseIsolatedStorageSpace(e.Result.Length);
    
          string VideoFile = "PlayFile.wmv";
          using(var isolatedStorageFileStream = new IsolatedStorageFileStream(VideoFile, FileMode.Create, isolatedStorageFile))
          {
            using(var stm = await response.Content.ReadAsStreamAsync())
            {
              stm.CopyTo(isolatedStorageFileStream);
            }
          }
        }
      }
      catch(Exception)
      {
        // TODO: add error handling
      }
    }
