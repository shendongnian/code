        using (var tagFile = TagLib.File.Create(destfile))
        {
            tagFile.Tag.Album = Album;
            tagFile.Tag.Title = Path.GetFileNameWithoutExtension(destfile);
            tagFile.Tag.AlbumArtists = new string[] { Artist };
            tagFile.Save();
        }
