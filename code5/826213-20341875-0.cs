		TagLib.File tagFile = TagLib.File.Create(@"C:\MySong.mp3");
		
		uint trackNumber = tagFile.Tag.Track;
		string songTitle = tagFile.Tag.Title;
		string artist = tagFile.Tag.AlbumArtists.FirstOrDefault();
		string albumTitle = tagFile.Tag.Album;
		uint year = tagFile.Tag.Year;
		string genre = tagFile.Tag.Genres.FirstOrDefault();
		
		MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
		System.Drawing.Image albumArt = System.Drawing.Image.FromStream(ms);
