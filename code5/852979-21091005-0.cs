    public void GetPlaylists
    {
       filesList = isoStore.GetFileNames("Playlists\\*").ToList();
       LongListMultiSelectorName.itemsSource = filesList;
    }
