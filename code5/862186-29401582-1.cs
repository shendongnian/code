    TagLib.Tag tempTag = null;
    TagLib.File tagFile = TagLib.File.Create(file);
    tempTag = new TagLib.Id3v2.Tag();
    tagFile.Tag.CopyTo(tempTag,true);
    tagFile.RemoveTags(TagLib.TagTypes.AllTags);
    tagFile.Save();
    tagFile.Dispose();
    
    
    TagLib.File tagFile2 = TagLib.File.Create(file);
    tempTag.CopyTo(tagFile2.Tag, true);
    tagFile2.Save();
    tagFile2.Dispose();
  
