    foreach (Match m in allDefs)
    {
    	foreach (Capture c in m.Groups[2].Captures)
    	{
        	Console.WriteLine(c.Value);
    	}
        Console.WriteLine("----");
    }
