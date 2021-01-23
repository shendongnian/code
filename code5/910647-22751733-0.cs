    private const int NotFound = -1;
    private static readonly IDictionary<char, int> MyLookup = new Dictionary<char, int>
    {
    	{ 'A', 2 },
    	{ 'B', 2 },
    	{ 'C', 2 },
    	{ 'D', 3 },
    	{ 'E', 3 },
    	{ 'F', 3 },
    	// and so on
    };
    
    public int DoStuff(char ch1)
    {
    	if (MyLookup.ContainsKey(ch1))
    	{
    		Console.WriteLine(MyLookup[ch1]);
    	}
    	else
    	{
    		Console.WriteLine(NotFound);
    	}
    }
