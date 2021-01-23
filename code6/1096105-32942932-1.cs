    private async Task HandleDownloadAsync(DownloadOperation downloadOperation)
    {
       allDownloads.Add(downloadOperation);
       ResponseInformation response = downloadOperation.GetResponseInformation();
       if (response.StatusCode == 200)
        {
          responseList.Add(response);
        }
        if (responseList.Count() == allDownloads.Count())
          {
            var total = BYTES * 100 / TOTALBYTES;
            if (total == 100)
             {
                 // do the success message here
             }
          }     
    }
