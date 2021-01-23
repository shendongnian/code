    var filepicker = new FileOpenPicker();
    filepicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
    filepicker.FileTypeFilter.Add(".wpl");
    filepicker.FileTypeFilter.Add(".zpl");
    filepicker.FileTypeFilter.Add(".m3u");
    var file = await filepicker.PickSingleFileAsync();
    
    if (file != null)
    {
        var playlist = await Playlist.LoadAsync(file); 
        var allMediaFiles = playlist.Files;
    }
