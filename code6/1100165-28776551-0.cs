    public void ItemData(string directory)
    {
		var r = new Regex(directory + "\\thumbnail-([0-9]+).jpg", RegexOptions.RightToLeft);
		thumbnails =
			Directory
				.GetFiles(this.directory)
				.Select(f => new
				{
					file = f,
					result = r.Match(f).Groups[1].Value
				})
				.Where(x => x.result != "")
				.Select(x => new
				{ 
					size = Int32.Parse(x.result),
					image = Image.FromFile(x.file)
				})
				.ToDictionary(x => x.size, x => x.image);
    }
