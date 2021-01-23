    string[] musicFiles = Directory.GetFiles(@"D:\mp3test", "*.mp3");
    // a structure to hold the filename and the tags object:
    public struct mp3FileTags
    {
        public string fileName { get; set; }
        public Id3Tag tags { get; set; }
        public mp3FileTags(string fn, Id3Tag t) 
        { this = new mp3FileTags(); fileName = fn; tags = t; }
    }
    // we create a list of the mp3FileTags objects:
    List<mp3FileTags> mp3s = new List<mp3FileTags>();
    foreach (string musicFile in musicFiles)
    {
        using (var mp3 = new Mp3File(musicFile))
        {
            Id3Tag tag = mp3.GetTag(Id3TagFamily.FileStartTag);
            mp3s.Add(new mp3FileTags(musicFile, tag));          // fill the list
        }
    }
    // now we can order it:
    mp3s = mp3s.OrderBy(o => o.tags.Artists.ToString()).ToList();
    // now we can use the ordered list:
    foreach (mp3FileTags FTag in mp3s)
    {
        Id3Tag tag = FTag.tags;
        Console.WriteLine("File: {0}", FTag.fileName);
        Console.WriteLine("Title: {0}", tag.Title.Value.);
        Console.WriteLine("Artist: {0}", tag.Artists.Value);
        Console.WriteLine("Album: {0}", tag.Album.Value);
    }
