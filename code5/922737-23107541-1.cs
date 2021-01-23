    const MAX_PARALLEL_UPLOADS = 5;
    async Task UploadFiles()
    {
        var files = new List<string>();
        // ... add files to the list
    
        // init the blob block and
        // upload files asynchronously
        using (var blobBlock = new CloudBlockBlob(url, credentials))
        using (var semaphore = new SemaphoreSlim(MAX_PARALLEL_UPLOADS))
        {
            var tasks = files.Select(async(filename) => 
            {
                await semaphore.WaitAsync();
                try
                {
                    await blobBlock.UploadFromFileAsync(filename, FileMode.Create);
                }
                finally
                {
                    semaphore.Release();
                }
            }).ToArray();
    
            await Task.WhenAll(tasks);
        }
    }
