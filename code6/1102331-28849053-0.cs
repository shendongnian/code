    public static async Task<bool> FileExistsForWp8(string filename)
    {
        StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;  
        try
        {
           StorageFile File = await folder.GetFileAsync(filename);
           return true;
        }
        catch
        {
            return false;
        }
    }
