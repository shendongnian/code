	// setup initial vars
	var myList = new List<bool>();
	for (int x = 0; x < 10000000; x++)
		myList.Add(false);	
	
	var containsAllFalse = false;
	Stopwatch sw = new Stopwatch();
	// start test
	sw.Start();
	containsAllFalse = !myList.Any(x => x);
	sw.Stop();
	// get result for Any
	var timeAny = sw.ElapsedMilliseconds;
	
	// reset variable state (just in case it affects anything)
	containsAllFalse = false;	
    // start test 2
	sw.Restart();
	containsAllFalse = myList.All(x => x == false);
	sw.Stop();
	// get result for All
	var timeAll = sw.ElapsedMilliseconds;
	// reset variable state (just in case it affects anything)
	containsAllFalse = false;	
	
	// start test 3
	sw.Restart();	
	containsAllFalse = !myList.Contains(true);			
	sw.Stop();
	
    // get result from Contains
	var timeContains = sw.ElapsedMilliseconds;
    // print results
    var percentFaster = Math.Round((double)timeAny / timeContains, 2);
	Console.WriteLine("Elapsed via Any = {0}ms", timeAny);
	Console.WriteLine("Elapsed via All = {0}ms", timeAll);
	Console.WriteLine("Elapsed via Contains = {0}ms", timeContains);
	Console.WriteLine("Contains is ~{0}x faster than Any!", percentFaster);
