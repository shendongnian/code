    StorageFolder picsFolder = KnownFolders.SavedPictures;
    StorageFile file = await picsFolder.CreateFileAsync("myImage.jpg", CreationCollisionOption.GenerateUniqueName);
    
    string url = "http://somewebsite.com/someimage.jpg";
    HttpClient client = new HttpClient();
    
    byte[] responseBytes = await client.GetByteArrayAsync(url);
    
    var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
    
    using (var outputStream = stream.GetOutputStreamAt(0))
    {
        DataWriter writer = new DataWriter(outputStream);
        writer.WriteBytes(responseBytes);
        writer.StoreAsync();
        outputStream.FlushAsync();
    }
