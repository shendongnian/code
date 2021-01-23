    public async Task<MemoryStream> LoadToStorage(string filename)
    {
        var localFolder = ApplicationData.Current.LocalFolder;
        var storageFile = await localFolder.GetFileAsync(filename);
    
        using (var fileStream = await storageFile.OpenStreamForReadAsync())
        {
            var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);
    
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
    }
