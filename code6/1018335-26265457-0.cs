    var httpClient = new HttpClient();
    var response = await httpClient.GetAsync(url);
    if (response.IsSuccessStatusCode)
    {
        var file = await response.Content.ReadAsByteArrayAsync();
        StorageFile destinationFile 
            = await KnownFolders.SavedPictures.CreateFileAsync("file.mp4",
                CreationCollisionOption.ReplaceExisting);
        Windows.Storage.Streams.IRandomAccessStream stream = await destinationFile.OpenAsync(FileAccessMode.ReadWrite);
        IOutputStream output = stream.GetOutputStreamAt(0);
        DataWriter writer = new DataWriter(output);
        writer.WriteBytes(file);
        await writer.StoreAsync();
        await output.FlushAsync();
    }
