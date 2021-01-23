    const MAX_PARALLEL_UPLOADS = 5;
    async Task UploadFiles()
    {
        // init the blob block
        var blobBlock = new CloudBlockBlob(url, credentials);
    
        var files = List<string>();
        // ... add files to the list
    
        // upload files asynchronously
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
