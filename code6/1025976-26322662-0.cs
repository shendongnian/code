	string[] filePaths = Directory.GetFiles(@"c:\textfiles\", "*.txt");
	
	foreach (string file in filePaths)
	{
		string[] lines = File.ReadAllLines(file);
			List<string> list_of_string = new List<string>();
		foreach (string line in lines)
		{
			list_of_string.Add( line.Replace("\n", "\r\n"));
		}
			File.WriteAllLines(file, list_of_string);
	}
