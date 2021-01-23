    using System;
    using System.Diagnostics;
    using System.Threading;
    
    class MainClass
    {
        static void Main()
        {
    	// Create new stopwatch
    	Stopwatch stopwatch = new Stopwatch();
    
    	// Begin timing
    	stopwatch.Start();
    
    	// Do something    
        var x = new {MyEnumerator = new List<int>() { 1, 2, 3 }.GetEnumerator()};
        while (x.MyEnumerator.MoveNext())
            Console.WriteLine(x.MyEnumerator.Current);
    
    	// Stop timing
    	stopwatch.Stop();
    
    	// Write result
    	Console.WriteLine("Time elapsed: {0}",
    	    stopwatch.Elapsed);
        }
    }
