    static void Main(string[] args)
    {
    	const int dictLength = 100000;
    	const int testCount = 1000000;
    			
    	var cdict = new ConcurrentDictionary<string, int>(GetRandomData(dictLength));
    	var dict = GetRandomData(dictLength).ToDictionary(x => x.Key, x => x.Value);
    
    	var stopwatch = new Stopwatch();
    	stopwatch.Start();
    	foreach (var pair in GetRandomData(testCount))
    		cdict.AddOrUpdate(pair.Key, 1, (x, y) => y+1);			
    
    	stopwatch.Stop();
    	Console.WriteLine("Concurrent dictionary: {0}", stopwatch.ElapsedMilliseconds);
    
    	stopwatch.Reset();
    	stopwatch.Start();
    
    	foreach (var pair in GetRandomData(testCount))
    		dict.AddOrUpdate(pair.Key, 1, (x, y) => y+1);	
    
    	stopwatch.Stop();
    	Console.WriteLine("Dictionary: {0}", stopwatch.ElapsedMilliseconds);
    	Console.ReadLine();
    }
    
    static IEnumerable<KeyValuePair<string, int>> GetRandomData(int count)
    {
    	const int constSeed = 100;
    	var randGenerator = new Random(constSeed);
    	return Enumerable.Range(0, count).Select((x, ind) => new KeyValuePair<string, int>(randGenerator.Next().ToString() + "_" + ind, randGenerator.Next()));
    }
