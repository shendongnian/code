    //File name
    const string f = "TextFile1.txt";
	// Declare new List.
	List<string> lines = new List<string>();
	// Use using StreamReader for disposing.
	using (StreamReader r = new StreamReader(f))
	{
	    string line;
	    while ((line = r.ReadLine()) != null)
	    {
		lines.Add(line);
	    }
    }
