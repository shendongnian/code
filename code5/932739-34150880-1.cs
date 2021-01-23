    var allSongList = 
      (await KnownFolders.MusicLibrary.GetFilesAsync(CommonFileQuery.OrderByName)).ToList();
    foreach (var file in allSongList)
    {
       var musicProperties = await file.Properties.GetMusicPropertiesAsync();
    }
