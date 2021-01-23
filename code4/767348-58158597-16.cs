    async Task<(bool Success, StorageFile File, Exception exception)> DoAsync(string fileName)
    {
        try
        {
            var folder = ApplicationData.Current.LocalCacheFolder;
            return (true, await folder.GetFileAsync(fileName), null);
        }
        catch (Exception exception)
        {
            return (false, null, exception);
        }
    }
