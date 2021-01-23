        void Main()
        {
        Console.WriteLine("starting on thread {0}",Thread.CurrentThread.ManagedThreadId);
	
    	GetSource()
    	.GroupBy(x => x % 10)
    	.Select(x => x.ObserveOn(TaskPoolScheduler.Default))
    	.SelectMany(g=>g.Aggregate(0, (s,i) =>ExpensiveAggregateFunctionNoTask(s,i)).SingleAsync())
    	.Subscribe(i=>Console.WriteLine("Got {0} on thread {1}",i,Thread.CurrentThread.ManagedThreadId))
    	;
        }// Define other methods and classes here
        static IObservable<int> GetSource()
        {
           return Enumerable.Range(0, 10)
        	.SelectMany(remainder => Enumerable.Range(0, 10).Select(i => 10 * i + remainder)).ToObservable();
        }
    
    
        int ExpensiveAggregateFunctionNoTask(int lastResult, int currentElement){
    	var r = lastResult+currentElement;
    	Console.WriteLine("Adding {0} and {1} on thread {2}", lastResult, currentElement, Thread.CurrentThread.ManagedThreadId);
    	Task.Delay(250).Wait(); //simulate expensive operation
    	return r;
        }
