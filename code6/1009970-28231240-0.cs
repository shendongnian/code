    static EventHandler _handler;
    static EventLoopScheduler _eventLoopScheduler = new EventLoopScheduler(); // synchronization for the consumers/subscribers and producers
    static ManualResetEventSlim _finish = new ManualResetEventSlim(); // just to check when this test end
    static int samples = 500; // number of times that will raise the event
    static int count = 0; // number of times that the event was received by the subscriber
    static void Main()
    {
    	var subscription = Observable.FromEventPattern(add => _handler += add, rem => _handler -= rem) // creating event composition
    			  .SubscribeOn(_eventLoopScheduler) // used to introduce synchronization when someone call subscribe in the composition
    			  //.ObserveOn(Scheduler.Default).Do(arg => DoSomething()) // Used to change the thread to let the _eventScheduler free for new consumers/subscribers
    			  .SelectMany(arg => Observable.FromAsync(a => Task.Run(() => DoSomething()))) // Using to change the thread to let the _eventScheduler free.... Used to introduce concurrency in the method execution
    			  .Subscribe(); // subscribe to receive the event
    			  
    	Parallel.For(0, samples, new ParallelOptions{ MaxDegreeOfParallelism = 4 }, a =>
    	{
    		Console.WriteLine(a.ToString("D4") + " | Trying to raise the event in thread:" + Thread.CurrentThread.ManagedThreadId);
    		_eventLoopScheduler.Schedule(() => 
    		{
    			Console.WriteLine(a.ToString("D4") + " | Raising event in thread:" + Thread.CurrentThread.ManagedThreadId);
    			_handler(null, EventArgs.Empty);
    		});
    	});
    	
    	_finish.Wait();
    	subscription.Dispose();
    	
    	_eventLoopScheduler.Dispose();
    	Console.WriteLine("Completed");
    }
    static void DoSomething()
    {
    	//var current = count++; // use this code ONLY if you are not introducing concurrency (which is without wrap the execution in another thread)
    	var current  = Interlocked.Increment(ref count); // to synchronize the count value, in this case it is necessary if you have the execution in multiple threads (such as using Task.Run or ThreadPool)
    	
    	var random = new Random(current);
    	Console.WriteLine(current.ToString("D4") + " | Doing Something in thread:" + Thread.CurrentThread.ManagedThreadId);
    	Thread.Sleep(random.Next(0,500)); // Simulate some Process
    	if (current == samples)
    	{
    		_finish.Set();
    	}
    }
