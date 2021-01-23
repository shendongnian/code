    private async Task<bool> CreateDb()
    {
        try
        {
            StorageFile storageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(DBFileName, CreationCollisionOption.OpenIfExists);
            DBpath = storageFile.Path;
            var dbconnection = new SQLiteAsyncConnection(DBpath, false);
            dbconnection.CreateTableAsync<Article>();
            //...
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(DBVersionFilename, CreationCollisionOption.ReplaceExisting);
            FileIO.WriteTextAsync(file, DBVersion);
            return true;
        }
        catch (Exception e)
        { }
        return false;
    }
