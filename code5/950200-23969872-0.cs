    MediaElement media = new MediaElement();
    
    using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    
    {
        using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(FileName, FileMode.Open, FileAccess.Read))
        {
             media.SetSource(fileStream);
             media.Play();
        }
    }
    grid.Children.Add(media);
