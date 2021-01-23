    async Task<string> CopyToLocalFolderAndReadContents(string strIncomingFileId)
    {
        StorageFolder objLocalFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
        objFile = await SharedStorageAccessManager.CopySharedFileAsync(objLocalFolder, TEMP.gmm, NameCollisionOption.ReplaceExisting, strIncomingFileId).ConfigureAwait(false);
    
        using (StreamReader streamReader = new StreamReader(objFile))
        {
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }
    }
