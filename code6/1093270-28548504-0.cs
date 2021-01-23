    static void Main(string[] args)
    {
        List<string> files = new List<string>()
        {
        "MySong.mp3",
        @"CD1\YourSong.mp3",
        "cover.jpg",
        @"CD2\TheSong.mp3"
        };
        var lookup = files.ToLookup(file => Path.GetDirectoryName(file));
        foreach (var item in lookup)
        {
            Debug.WriteLine(item.Key);
            foreach (var subitem in item)
            {
                Debug.WriteLine("  " + subitem);
            }
        }
    }
