	private void CalculateFiles()
	{
		var builder = new StringBuilder();
		var fileGroupByExtension = new DirectoryInfo(this.DirectoryPath)
										.GetFiles(SearchPattern,SearchOption.AllDirectories)
										.GroupBy(t => t.Extension)
										.OrderBy(t => t.Key);
		foreach (var grp in fileGroupByExtension)
		{
			var extension = grp.Key;
			builder.AppendLine(extension + ":");
			foreach (var file in grp)
			{
				builder.AppendLine(file.FullName + " ....... " + (file.Length/1000) + "KB");
			}
		}
		Console.Write(builder.ToString());
	}
