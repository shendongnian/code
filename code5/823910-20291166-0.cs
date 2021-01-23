    private async void SaveColorArray(string filename, Color[] array)
    {
        StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(filename + ".dat", CreationCollisionOption.ReplaceExisting);
        IRandomAccessStream writeStream = await sampleFile.OpenAsync(FileAccessMode.ReadWrite);
        IOutputStream outputSteam = writeStream.GetOutputStreamAt(0);
        DataWriter dataWriter = new DataWriter(outputSteam);
        for (int i = 0; i < array.Length; i++)
        {
            dataWriter.WriteByte(array[i].R);
            dataWriter.WriteByte(array[i].G);
            dataWriter.WriteByte(array[i].B);
            dataWriter.WriteByte(array[i].A);
        }
        await dataWriter.StoreAsync();
        await outputSteam.FlushAsync();
    }
    protected async Task<Color[]> LoadColorArray(string filename)
    {
        StorageFile sampleFile = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(filename + ".dat", CreationCollisionOption.OpenIfExists);
        IRandomAccessStream readStream = await sampleFile.OpenAsync(FileAccessMode.Read);
        IInputStream inputSteam = readStream.GetInputStreamAt(0);
        DataReader dataReader = new DataReader(inputSteam);
        await dataReader.LoadAsync((uint)readStream.Size);
        Color[] levelArray = new Color[dataReader.UnconsumedBufferLength / 4];
        int i = 0;
        while (dataReader.UnconsumedBufferLength > 0)
        {
            byte[] colorArray = new byte[4];
            dataReader.ReadBytes(colorArray);
            levelArray[i++] = new Color(colorArray[0], colorArray[1], colorArray[2], colorArray[3]);
        }
        return levelArray;
    }
