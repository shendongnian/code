    async Task<string> CopyToLocalFolderAndReadContents(string strIncomingFileId)
    {
        StorageFolder objLocalFolder = Windows.Storage.ApplicationData.Current
                                                                      .LocalFolder;
        objFile = await SharedStorageAccessManager
                       .CopySharedFileAsync(objLocalFolder, TEMP.gmm, 
                                            NameCollisionOption.ReplaceExisting, 
                                            strIncomingFileId)
                       .AsTask().ConfigureAwait(false);
        using (StreamReader streamReader = new StreamReader
              (await objFile.OpenStreamForReadAsync().ConfigureAwait(false)))
        {
            return await streamReader.ReadToEndAsync().ConfigureAwait(false);
        }
    }
