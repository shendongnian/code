    // first define Cancellation Token Source - I've made it global so that CancelButton has acces to it
    CancellationTokenSource cts = new CancellationTokenSource();
    enum Problem { Ok, Cancelled, Other }; // results of my Task
    // cancelling button event
    private void CancellButton_Click(object sender, RoutedEventArgs e)
    {
       if (this.cts != null)
            this.cts.Cancel();
    }
    // the main method - I've described it a little below in the text
    public async Task<Problem> DownloadFileFromWeb(Uri uriToDownload, string fileName, CancellationToken cToken)
    {
       try
       {
           using (Stream mystr = await DownloadFile(uriToDownload))
               using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
               {
               if (ISF.FileExists(fileName)) return Problem.Other;
               using (IsolatedStorageFileStream file = ISF.CreateFile(fileName))
               {
                   const int BUFFER_SIZE = 1024;
                   byte[] buf = new byte[BUFFER_SIZE];
                   int bytesread = 0;
                   while ((bytesread = await mystr.ReadAsync(buf, 0, BUFFER_SIZE)) > 0)
                   {
                      cToken.ThrowIfCancellationRequested();
                      file.Write(buf, 0, bytesread);
                   }
               }
           }
           return Problem.Ok;
        }
        catch (Exception exc)
        {
           if (exc is OperationCanceledException)
               return Problem.Cancelled;
           else return Problem.Other; 
        }
    }
    // and download
    private async void Downlaod_Click(object sender, RoutedEventArgs e)
    {
       cts = new CancellationTokenSource();
       Problem fileDownloaded = await DownloadFileFromWeb(new Uri(@"http://filedress/myfile.txt", UriKind.Absolute), "myfile.txt", cts.Token);
       switch(fileDownloaded)
       {
          case Problem.Ok:
               MessageBox.Show("File downloaded");
               break;
          case Problem.Cancelled:
               MessageBox.Show("Download cancelled");
               break;
          case Problem.Other:
          default:
               MessageBox.Show("Other problem with download");
               break;
        }
    }
