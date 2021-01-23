    var storage = IsolatedStorageFile.GetUserStoreForApplication();
    using (var fileStream = storage.CreateFile(fileName))
    {
        //Write the data
        using (var isoFileWriter = new StreamWriter(fileStream))
        {
            var json = JsonConvert.SerializeObject(rigaStorico.Reverse());
            isoFileWriter.WriteLine(json);
        }
    }
