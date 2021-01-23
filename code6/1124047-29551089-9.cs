    async Task<bool> continueToReadAllFiles(StorageFolder folder)
    {
        if (folder == null)
            return false;
        if (folder.Name.Equals("RpgApp", StringComparison.CurrentCultureIgnoreCase))
        {
            var files = await folder.GetFilesAsync();
            foreach (var file in files)
            {
                test.Add(file.Name);
            }
            return false;
        }
        var folders = await folder.GetFoldersAsync();
        foreach (var child in folders)
            if (!await continueToReadAllFiles(child))
                return false;
    
        return true;
    }
    
    
    public async void buttonTest()
    {
        test.Clear();
        StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
        var folders = await externalDevices.GetFoldersAsync();
        foreach (var folder in folders)
        {
            if (!await continueToReadAllFiles(folder))
                break;
        }
        //.... commented out
    }
