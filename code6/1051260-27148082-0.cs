	public IEnumerable<string> ReadAllZippedLines(string filename)
	{
		using (var fileStream = File.OpenRead(filename))
		{
			using (var gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
			{
				using (var reader = new StreamReader(gzipStream)) 
				{
					yield return reader.ReadLine();
				}
			}
		}
	}
