    var file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
    {
       using(var outputStream = stream.GetOutputStreamAt(0))
       {
           var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream);
           dataWriter.WriteBytes(...);
           await dataWriter.StoreAsync();
           dataWriter.DetachStream();
           await outputStream.FlushAsync();
       }
    }
