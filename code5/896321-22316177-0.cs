	int lineNr = 1;
	using (FileStream fs = File.Open(pathToTheFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
	using (BufferedStream bs = new BufferedStream(fs))
	using (CsvReader csv = new CsvReader(new StreamReader(bs), true))
	{
		while (csv.ReadNextRecord())
		{
			if (YouCareAboutLine(lineNr))
			{
			    DoSomethingWithThisLine();
			}
			lineNr++;
		}
	}
