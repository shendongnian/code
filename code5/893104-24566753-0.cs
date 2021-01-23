    IReadOnlyList<Windows.Storage.StorageFile> resultsLibrary; 
    // to store the library
    resultsLibrary = await Windows.Storage.KnownFolders.MusicLibrary.GetFilesAsync(CommonFileQuery.OrderByName);
    // this is the list created.
    //and this is what shows the media library in a list in xaml
     length = resultsLibrary.Count;
                list.Items.Clear();
                for (int j = 0; j < length; j++)
                {
                    list.Items.Add(resultsLibrary[j].Name);
                }
