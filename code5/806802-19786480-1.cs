	private void CalculateFiles()
	{
		var builder = new StringBuilder();
		var fileGroupByExtension = new DirectoryInfo(this.DirectoryPath)
										.GetFiles(SearchPattern,SearchOption.AllDirectories)
										.GroupBy(f => f.Extension)
										.OrderBy(grp => grp.Key);
		foreach (var grp in fileGroupByExtension)
		{
			var extension = grp.Key;
			builder.Append(extension);
			builder.Append(":");
			builder.AppendLine();
			foreach (var file in grp.OrderBy(f => f.Name))
			{
                builder.Append(file.Name);
                builder.Append(" ....... ");
                builder.Append(file.Length/1000);
                builder.Append("KB");
				builder.AppendLine();
			}
		}
		Console.Write(builder.ToString());
	}
