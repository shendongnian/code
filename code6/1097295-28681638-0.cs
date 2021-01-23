    public async Task SaveStreamToFile(Stream streamToSave, string fileName, CancellationToken cancelToken)
    {
        Byte[] buf= Encoding.Unicode.GetBytes(content);
        var folder = ApplicationData.Current.LocalFolder;
        StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        using (Stream fileStram = await file.OpenStreamForWriteAsync())
        {    
            int bytesread = 0;
            while ((bytesread = await streamToSave.ReadAsync(buf, 0, BUFFER_SIZE)) > 0)
            {
                await fileStram.WriteAsync(buf, 0, bytesread);
                cancelToken.ThrowIfCancellationRequested();
            }
        }
    }
