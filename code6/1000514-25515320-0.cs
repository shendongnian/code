	public static IEnumerable<string> ReadLineFromFile(TextReader fileReader)
	{
		using (fileReader)
		{
			string currentLine;
			while ((currentLine = fileReader.ReadLine()) != null)
			{
				yield return currentLine;
			}
		}
	}
