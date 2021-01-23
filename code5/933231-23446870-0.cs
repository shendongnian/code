    public async Task<long> GetFreeSpace()
    {
        StorageFolder local = ApplicationData.Current.LocalFolder;
        var retrivedProperties = await local.Properties.RetrievePropertiesAsync(new string[] { "System.FreeSpace" });
        string freeSpace = retrivedProperties["System.FreeSpace"].ToString();
        return long.Parse(freeSpace);
    }
    // usage:
    long myFreeSpace = await GetFreeSpace();
