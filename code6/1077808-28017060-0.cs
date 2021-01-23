    public static void Main()
	{
		var query = Enumerable.Range(0,10).Select(x => GetNumber(x)).Any(x => x > 5);		
	}
	
	
	public static int GetNumber(int x)
	{
		Console.WriteLine("GetNumber is called: {0}", x);
		return x;
	}
    // Output:
    GetNumber is called: 0
    GetNumber is called: 1
    GetNumber is called: 2
    GetNumber is called: 3
    GetNumber is called: 4
    GetNumber is called: 5
    GetNumber is called: 6
