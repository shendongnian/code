    List<StorageFolder> folders = new List<StorageFolder>();
    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    // ...
    Windows.Storage.ApplicationDataCompositeValue data = new Windows.Storage.ApplicationDataCompositeValue();
    var i = 0;
    foreach (var item in folders)
    {
        if (item.Path == null || item.Path == "")
            continue;
        data[i.ToString()] = item.Path; // this is the line where I get the exception
        i = i + 1;
    }
    localSettings.Values["folders"] = data;
