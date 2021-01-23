    TagLib.Ogg.File oggFile = (TagLib.Ogg.File)TagLib.File.Create(@"C:\music.ogg");
            
    PropertyInfo headerProp = oggFile.GetType()
                                     .GetProperty("LastPageHeader", BindingFlags.Instance | BindingFlags.NonPublic);
    TagLib.Ogg.PageHeader header = (TagLib.Ogg.PageHeader)headerProp.GetValue(oggFile);
    TagLib.Flac.Picture pic = new TagLib.Flac.Picture(new TagLib.Flac.Picture(@"C:\img.jpeg"));
    TagLib.ByteVector picData = pic.Render();
    TagLib.Ogg.GroupedComment groupedCommentTag = (TagLib.Ogg.GroupedComment)oggFile.Tag;
    TagLib.Ogg.XiphComment xiphComment = groupedCommentTag.GetComment(header.StreamSerialNumber);
    xiphComment.SetField("METADATA_BLOCK_PICTURE", Convert.ToBase64String(picData.Data));
    oggFile.Save();
