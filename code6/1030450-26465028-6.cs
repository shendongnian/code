    private static void Main(string[] args)
    {
    	var sample = Enumerable.Range(0, 100000).ToList();
    
    	var z1 = Stopwatch.StartNew();
    	for (int i = 0; i < 1000; i++)
    	{
    		Test1(sample);
    	}
    
    	z1.Stop();
    	Console.WriteLine(z1.ElapsedMilliseconds);
    
    	var z2 = Stopwatch.StartNew();
    	for (int i = 0; i < 1000; i++)
    	{
    		Test2(sample);
    	}
    
    	z2.Stop();
    	Console.WriteLine(z2.ElapsedMilliseconds);
    
    	Console.Read();
    }
    
    private static void Test1(IList<int> input)
    {
    	var res2 = input
    		.Select((z, i) => i % 2 == 0
    			? input[i / 2]
    			: input[input.Count - i / 2 - 1])
    		.ToList();
    }
    
    private static void Test2(IList<int> input)
    {
    	int count = input.Count;
    	var res = new List<int>(count);
    
    	for (int i = 0; i < input.Count; i++)
    	{
    		var iDividedByRwo = i / 2;
    		if (i % 2 == 0)
    		{
    			res.Add(input[iDividedByRwo]);
    		}
    		else
    		{
    			res.Add(input[count - iDividedByRwo - 1]);
    		}
    	}
    }
