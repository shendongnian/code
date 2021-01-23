    MediaLibrary library=new MediaLibrary();
    SongMetadata smd=new SongMetadata()
    {
        AlbumName = "AlbumName",
        Duration = TimeSpan.FromMinutes(2.50),
        Name = "SongName" 
    };
    MediaLibraryExtensions.SaveSong(library, new Uri(filePath, UriKind.RelativeOrAbsolute), smd, SaveSongOperation.CopyToLibrary);
