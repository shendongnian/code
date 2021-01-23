    ulong musicFolderSize = (ulong)ApplicationData.Current.LocalSettings.Values["musicFolderSize"];
    BasicProperties props = await KnownFolders.MusicLibrary.GetBasicPropertiesAsync();
    if (props.Size != musicFolderSize)
    {
        //  ...
        ApplicationData.Current.LocalSettings.Values["musicFolderSize"] = props.Size;
    }
