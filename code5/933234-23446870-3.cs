    public async Task<UInt64> GetFreeSpace(StorageFolder folder)
    {
        var retrivedProperties = await folder.Properties.RetrievePropertiesAsync(new string[] { "System.FreeSpace" });
        return (UInt64)retrivedProperties["System.FreeSpace"];
    }
    // and use it like this:
    UInt64 spaceOfInstallationFolder = await GetFreeSpace(ApplicationData.Current.LocalFolder);
    UInt64 spaceOfMusicLibrary = await GetFreeSpace(KnownFolders.MusicLibrary);
