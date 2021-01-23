    List<string> SongList = new List<string>();
    string path = @"C:\Users\Toby\Music";
    string[] Songs = Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly);
    SongList.Add("");
    SongList.Add("There are " + Songs.Length + " songs");
    foreach (string Asong in Songs)
    {
        string sFileNameWithOutExtension = Path.GetFileNameWithoutExtension(Asong);
        SongList.Add(sFileNameWithOutExtension);
    }
            
    SongBox.DataSource = SongList;
