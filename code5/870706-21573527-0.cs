    public async Task<bool> DownloadFileFromWeb(Uri uriToDownload, string fileName)
    {
       try
       {
          using (Stream mystr = await DownloadFile(uriToDownload))
           using (IsolatedStorageFile ISF = IsolatedStorageFile.GetUserStoreForApplication())
           {
               if (ISF.FileExists(fileName)) return false;
               using (IsolatedStorageFileStream file = ISF.CreateFile(fileName))
               {
                   const int BUFFER_SIZE = 1024;
                   byte[] buf = new byte[BUFFER_SIZE];
                   int bytesread = 0;
                   while ((bytesread = await mystr.ReadAsync(buf, 0, BUFFER_SIZE)) > 0)
                        file.Write(buf, 0, bytesread);
               }
           }
           return true;
        }
        catch { return false; }
    }
    private async void Downlaod_Click(object sender, RoutedEventArgs e)
    {
       bool fileDownloaded = await DownloadFileFromWeb(new Uri(@"http://filedress/myfile.txt", UriKind.Absolute), "myfile.txt");
       if (!fileDownloaded) MessageBox.Show("Problem with download");
    }
