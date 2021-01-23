    public async Task DownloadAsync()
    { 
        // Save blob contents to a file.
        using (FileStream fileStream = System.IO.File.OpenWrite(TempPath))
        {
            CloudBlockBlob blockBlob = Container.GetBlockBlobReference(BlobReference);    
            await blockBlob.DownloadToStreamAsync(fileStream);
        }
    }
    public async Task BeginDownloadAsync()
    {
        await DownloadAsync();
    }
