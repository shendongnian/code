    public async Task<UInt64> GetFreeSpace()
    {
        StorageFolder local = ApplicationData.Current.LocalFolder;
        var retrivedProperties = await local.Properties.RetrievePropertiesAsync(new string[] { "System.FreeSpace" });
        return (UInt64)retrivedProperties["System.FreeSpace"];
    }
    // usage:
    UInt64 myFreeSpace = await GetFreeSpace();
