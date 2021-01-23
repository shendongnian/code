    internal async Task<Attempt<T>> TryReadObjectAsync<T>(string folderName, string fileName)
    {
        if (String.IsNullOrWhiteSpace(folderName))
            throw new ArgumentException("The string argument is null or whitespace.", "folderName");
        if (String.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("The string argument is null or whitespace.", "fileName");
               
        try
        {
            StorageFolder folder = this.StorageFolder;                
            if (folderName != @"\")
                folder = await StorageFolder.GetFolderAsync(folderName);
            var file = await folder.GetFileAsync(fileName);
            var buffy = await FileIO.ReadBufferAsync(file);
            string xml = await buffy.ReadUTF8Async();
            T obj = await Evoq.Serialization.DataContractSerializerHelper.DeserializeAsync<T>(xml);
            return new Attempt<T>(obj);
        }
        catch (FileNotFoundException fnfe)
        {
            // Only catch and wrap expected exceptions.
            return new Attempt<T>(fnfe);
        }
    }
