    // class member
    SemaphoreSlim  _semaphore = new SemaphoreSlim(1); 
    
    public static async Task<string> BackgroundUploadFile<T>(..)
    {
        // ...
        
        LiveOperationResult liveOpResult;
        await _semaphore.WaitAsync();
        try
        {
            liveOpResult = await Client.BackgroundUploadAsync(
                skydriveFolderId,
                new Uri("/shared/transfers/" + fileNameInSkyDrive, UriKind.Relative),
                OverwriteOption.Overwrite);
        }
        finally
        {
            _semaphore.Release();
        }
        // ...
    }
