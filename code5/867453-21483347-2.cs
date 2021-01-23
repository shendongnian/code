    private async string GetDbPath( string fileName)
      {
       if (await DoesFileExistAsync(fileName))
          {
           // file exists;
           string  DBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
            fileName);
         }
       else
          {
          // file does not exist
           StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(fileName);
          await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder);
    string  DBPath=Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
          }
    }
                
    private async Task<bool> DoesFileExistAsync(string fileName)
       {
         try
          {
           await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return true;
           }
         catch
         {
          return false;
         }
      }
