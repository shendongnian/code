    private void fmUpdateingDatabaseDialog_Shown(object sender, EventArgs e)
    {
      device.Connect();
      lbInformation.Text = "uploading database to " + device.FriendlyName;
      device.Disconnect();
      var progress = new Progress<T>(data =>
      {
        // TODO: move worker_ProgressChanged code into here.
      });
      await DownloadAsync(progress);
      // TODO: move worker_RunWorkerCompleted code here.
    }
    private async Task DownloadAsync(IProgress<T> progress)
    {
      //download files temporary
      WebClient client = new WebClient();
      client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
      await client.DownloadFileTaskAsync(new Uri(""), Path.Combine(tempPath + ""));
      WebClient client2 = new WebClient();
      client2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client2_DownloadProgressChanged);
      await client2.DownloadFileTaskAsync(new Uri(""), Path.Combine(tempPath + ""));
      //upload files to phone
      // TODO: Check for Async versions of these methods that you can await.
      //  If there aren't any, consider using Task.Run.
      device.Connect();
      device.TransferContentToDevice(Path.Combine(tempPath+""), folder.Id, folder, true);
      device.TransferContentToDevice(Path.Combine(tempPath+""), folder.Id, folder, true);
      device.Disconnect();
    }
