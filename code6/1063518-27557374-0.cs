    string[] musicFiles = Directory.GetFiles(@"D:\mp3test", "*.mp3");
    // we create a list of the Id3Tag objects:
    List<Id3Tag> mp3s = new List<Id3Tag>();
    foreach (string musicFile in musicFiles)
    {
        using (var mp3 = new Mp3File(musicFile))
        {
            Id3Tag tag = mp3.GetTag(Id3TagFamily.FileStartTag);
            mp3s.Add(tag);                    // fill the list
        }
    }
    // now we can order it:
    mp3s = mp3s.OrderBy( o => o.Artists.ToString()).ToList();
    // now we can use the ordered list:
    foreach (Id3Tag tag in mp3s)
    {
        Console.WriteLine("Title: {0}", tag.Title.Value.);
        Console.WriteLine("Artist: {0}", tag.Artists.Value);
        Console.WriteLine("Album: {0}", tag.Album.Value);
    }
