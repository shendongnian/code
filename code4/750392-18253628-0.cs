    TagLib.File file = TagLib.File.Create(mp3FileName);
    file.Tag.Title = "some title"; // you've got this
    TagLib.Id3v2.Tag tag = (TagLib.Id3v2.Tag)file.GetTag(TagTypes.Id3v2);
    tag.SetTextFrame("WOAR", "some url"); // WOAR = Official artist/performer webpage
    file.Save();
