	public static IEnumerable<string> ReadFile(string path)
	{
		string line;
		
		using(var reader = File.OpenText(path))
			while((line = reader.ReadLine()) != null)
				yield return line;
	}
