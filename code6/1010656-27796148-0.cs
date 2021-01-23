        IReadOnlyList<IStorageItem> VideoLibrary = await KnownFolders.VideosLibrary.GetFoldersAsync();
        int count= GetCount(VideoLibrary);
        private async Task<string> GetCount(IReadOnlyList<IStorageItem> VideoLibraryItems)
        {
                foreach (IStorageItem vItem in VideoLibraryItems)
                {
                    IStorageItem item = vItem;
                    if (item.IsOfType(Windows.Storage.StorageItemTypes.Folder))
                    {
                        StorageFolder sfolder = (StorageFolder)item;
                        IReadOnlyList<IStorageItem> fileList = await sfolder.GetItemsAsync();
                        return fileList.Count
		    }
                    else if(item.IsOfType(Windows.Storage.StorageItemTypes.File))
		    {
                        StorageFile sf = (StorageFile)item;
			return sf.Count;
                    }
                }
        }
