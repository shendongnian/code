    private Task<string> GetString(Uri uri)
    {
       TaskCompletionSource<string> taskComplete = new TaskCompletionSource<string>();
       WebClient client = new WebClient();
       client.DownloadStringCompleted += (s, e) =>
       {
         if (e.Error == null) taskComplete.SetResult(e.Result);
         else taskComplete.SetException(e.Error);
       };
       client.DownloadStringAsync(uri);
       return taskComplete.Task;
    }
    private async Task myTask()            
    {
      isBusy = true;
      isBusyMessage = "Loading...";
      Uri uri = new Uri(transportURL1 + latitude + "%2C" + longitude + transportURL2, UriKind.Absolute);
      string resultDownload = await GetString(uri);
      try
      {
        RootObject result = JsonConvert.DeserializeObject<RootObject>(resultDownload);
        hereRestProperty = new ObservableCollection<Item>(results.items);
      }
      catch (Exception err)                 
      {
        MessageBox.Show(err.Message);
      }
      isBusy = false;
      isBusyMessage = "Finished";
    }
