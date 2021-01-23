    List<string> SongList = new List<string>();
    string path = @"C:\Users\Toby\Music";
    string[] Songs = Directory.GetFiles(path, "*.mp3", SearchOption.TopDirectoryOnly);
    
    foreach (string Asong in Songs)
    {
        SongList.Add(Path.GetFileName(Asong));           
    }
    SongList.Add("");
    SongList.Add("There are " + Songs.Length + " songs");
    SongBox.DataSource = SongList;
