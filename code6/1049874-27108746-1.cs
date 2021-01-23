    private async void SeeFolders(IReadOnlyList<IStorageItem> MusicFolderList)
    {
       List<MusicF> foldersList = new List<MusicF>();
       try
       {
    
          foreach(IStorageItem mItem in MusicFolderList)
          {
             IStorageItem item = mItem;
             int temp = 0;
             // Checks if the item is a Folder
             if(item.IsOfType(Windows.Storage.StorageItemTypes.Folder))
             {                       
                StorageFolder mFolder = (StorageFolder)item;
                // To get all Items (Files & Folders) present in the folder
                IReadOnlyList<IStorageItem> fileList = await mFolder.GetItemsAsync();
    
                // checks the count. If folder contains any files or sub-folders, fetch details & then traverse through the fileList.
                if(fileList.Count >0)
                {
                   // create object of MusicAlbums() class.
                   MusicF musicAlbumObj = new MusicAlbums();
    
                   // set name of item Folder.
                   musicAlbumObj.strName = item.Name;
    
                   // set path of item Folder.
                   musicAlbumObj.strPath = item.Path;
                   foldersList.Add(musicAlbumObj);
    
    
                   string showText = "";
                   showText = musicAlbumObj.strName + " *** " + musicAlbumObj.strPath;
                   MessageDialog msg = new MessageDialog(showText);
                   await msg.ShowAsync(); 
                }                      
             }                 
          }
          ViewMusicFolders.ItemsSource = foldersList;
       }
       catch {}
    }
