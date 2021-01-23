    ...
    try
    {
    	using (var stream = entry.OpenReader())
    	using (var reader = new StreamReader(stream))
    	{
    		string line;
    		while ((line = streamReader.ReadLine()) != null)
    		{
    			if (line.Contains(sSearchTerm))
    			{ logs.Info("{0} contains \"{1}\"", file.Name, sSearchTerm); break; }
    			else
    			{ Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("{0} does not contain \"{1}\"", file.Name, sSearchTerm); Console.ResetColor(); break; }
    		}
    	}
    }
    ...
