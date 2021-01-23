    static Dictionary<string, string> Extensions = new Dictionary<string, string>();
    public async static Task<string> GetDisplayText(string extension)
    {
        if (Extensions.ContainsKey(extension)) { return Extensions[extension]; }
        var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        var file = await localFolder.CreateFileAsync("file-test" + extension, 
            Windows.Storage.CreationCollisionOption.ReplaceExisting);
        var displayType = file.DisplayType;
        Extensions[extension] = displayType;
        await file.DeleteAsync();
        return displayType;
    }
