    List<string> lines = new List<string>();
    // Read the file and add all lines to the "lines" List
	using (StreamReader r = new StreamReader(file))
	{
	    string line;
	    while ((line = r.ReadLine()) != null)
	    {
		   lines.Add(line);
	    }
	}
    // Insert the text at the 2nd index
    lines.Insert(2, "I like eating pasta");
