	void Main()
	{
		var els = new EventLoopScheduler();
		var dispatcher = new EventLoopScheduler();
				
		Stream()
			.SubscribeOn(els) //TODO: Move to line just before ObserveOn
			.Select(DoCalc)
			.ObserveOn(dispatcher)
			.Subscribe(Update);	
	}
	
	// Define other methods and classes here
	private IObservable<string> Stream()
	{
		return Observable.Create<string>
		(
			(IObserver<string> observer) =>
			{
				observer.OnNext("a");
				Thread.Sleep(1000);
				observer.OnNext("b");
				observer.OnCompleted();         
				return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
			}
		);
	}
	private string DoCalc(string val)
	{
		val.Dump("DoCalc()");
		Thread.Sleep(1000);
		return val;
	}
	private void Update(string val)
	{
		val.Dump("Update()");
	}
 
