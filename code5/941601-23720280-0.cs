    public async Task SaveStreamToFile(Stream streamToSave, string fileName, CancellationToken cancelToken)
    {
        StorageFile file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        using (Stream fileStram = await file.OpenStreamForWriteAsync())
        {
            const int BUFFER_SIZE = 1024;
            byte[] buf = new byte[BUFFER_SIZE];
            int bytesread = 0;
            while ((bytesread = await streamToSave.ReadAsync(buf, 0, BUFFER_SIZE)) > 0)
            {
                await fileStram.WriteAsync(buf, 0, bytesread);
                cancelToken.ThrowIfCancellationRequested();
            }
        }
    }
