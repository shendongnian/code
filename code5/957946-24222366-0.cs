    public static async Task<IStorageItem> CreatePath(this StorageFolder folder, string fileLocation, CreationCollisionOption fileCollisionOption, CreationCollisionOption folderCollisionOption)
    {
        var localFilePath = PathHelper.ToLocalPath(fileLocation).Replace(PathHelper.ToLocalPath(folder.Path), "");
        if (localFilePath.Length > 0 && (localFilePath[0] == '/' || localFilePath[0] == '\\'))
        {
            localFilePath = localFilePath.Remove(0, 1);
        }
        if (localFilePath.Length == 0)
        {
            return folder;
        }
        var separatorIndex = localFilePath.IndexOfAny(new char[] { '/', '\\' });
        if (separatorIndex == -1)
        {
            return await folder.CreateFileAsync(localFilePath, fileCollisionOption);
        }
        else
        {
            var folderName = localFilePath.Substring(0, separatorIndex);
            var subFolder = await folder.CreateFolderAsync(folderName, folderCollisionOption);
            return await subFolder.CreatePath(fileLocation.Substring(separatorIndex + 1), fileCollisionOption, folderCollisionOption);
        }
    }
    public static async Task ExtractToFolderAsync(this ZipArchive archive, StorageFolder folder)
    {
        foreach (var entry in archive.Entries)
        {
            var storageItem = await folder.CreatePathAsync(entry.FullName, CreationCollisionOption.OpenIfExists, CreationCollisionOption.OpenIfExists);
            StorageFile file;
            if ((file = storageItem as StorageFile) != null)
            {
                using (var fileStream = await file.OpenStreamForWriteAsync())
                {
                    using (var entryStream = entry.Open())
                    {
                        await entryStream.CopyToAsync(fileStream);
                    }
                }
            }
        }
    }
