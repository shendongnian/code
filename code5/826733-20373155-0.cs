     var storageAssets = await ExternalStorage.GetExternalStorageDevicesAsync();
     ExternalStorageDevice item = storageAssets.FirstOrDefault();
     ExternalStorageFolder folder = item.RootFolder;
     var _folderList = await folder.GetFoldersAsync();
     foreach (var _folder in _folderList)
     {
     Debug.WriteLine(_folder.Name);
     }
