    public async static Task<string> GetDisplayText(string extension)
    {
        var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        var file = await localFolder.CreateFileAsync("temp1." + extension, 
            Windows.Storage.CreationCollisionOption.ReplaceExisting);
        var displayType = file.DisplayType;
        await file.DeleteAsync();
        return displayType;
    }
