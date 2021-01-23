    public ObservableCollection<Album> Albums{get;set;}
    foreach (DirectoryInfo diNext in dirs)
    {
          foreach (FileInfo test in diNext.GetFileSystemInfos("*"+tb+"*"+".mp3", SearchOption.AllDirectories))
          {
                        u.Read(test.FullName);
                        Album album = new Album;
                        album.Track = u.Title;
                        album.Artist = u.Artist;
                        Albums.Add(album);
           }
     }
