    lock (_Lock)
    {
    	while (staticVar <= 99999) //note the <= comparison change
    	{ staticVar++; }
    	while (instanceVar <= 99999) //note the <= comparison change
    	{ instanceVar++; }
    	if (instanceVar != 100000)
    	{ Console.WriteLine("I1=" + instanceVar.ToString()); }
    	if (staticVar != 100000)
    	{ Console.WriteLine(("S1=" + staticVar.ToString())); }
    }
