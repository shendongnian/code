    async Task<bool> DoAsync(string fileName, Action<StorageFile> file, Action<Exception> error)
    {
        try
        {
            var folder = ApplicationData.Current.LocalCacheFolder;
            file?.Invoke(await folder.GetFileAsync(fileName));
            return true;
        }
        catch (Exception exception)
        {
            error?.Invoke(exception);
            return false;
        }
    }
