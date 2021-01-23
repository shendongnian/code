            string title;
			using (var taglibFile = TagLib.File.Create(file))
			{
				title = taglibFile.Tag.Title;
				taglibFile.RemoveTags(TagTypes.AllTags);
				taglibFile.Save();
			}
			using (var tagLibFile = TagLib.File.Create(file))
			{
				tagLibFile.Tag.Title = title;
				tagLibFile.Save();
			}
