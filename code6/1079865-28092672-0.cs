    void Main()
    {
        //JIT
        Test(0);
    
    	Test(100);
     	Test(1000);
    	Test(10000);
    	Test(1000000);
    	Test(10000000);
    }
    public void Test(int itemAmount)
    {
    	string[] strings = Enumerable.Range(0, itemAmount).Select(i => Guid.NewGuid()
                                                          .ToString()).ToArray();
    
    	var stopWatch = Stopwatch.StartNew();
    	CountStringInParallel(strings, itemAmount);
    	stopWatch.Stop();
    	Console.WriteLine("Parallel Call: String amount: {0}, Time: {1}", 
                                                            itemAmount, stopWatch.Elapsed);
    	
    	stopWatch.Restart();
    	CountStringSync(strings, itemAmount);
    	stopWatch.Stop();
    	Console.WriteLine("Synchronous Call: String amount: {0}, Time: {1}", 
                                                            itemAmount, stopWatch.Elapsed);
    }
