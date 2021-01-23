	[Fact]
	public void repro()
	{
		var scheduler = new TestScheduler();
		var count = 0;
		// this observable is a simplification of the system under test
		// I've just included it directly in the test for clarity
		// in reality it is NOT accessible from the test code - it is
		// an implementation detail of the system under test
		// but by passing in a TestScheduler to the sut, the test code
		// can theoretically control the execution of the pipeline
		// but per this question, that doesn't work when using FromAsync
		Observable
			.Return(1)
			.Select(_ => Observable.FromAsync(()=>Whatever(scheduler)))
			.Concat()
			.ObserveOn(scheduler)
			.Subscribe(_ => Interlocked.Increment(ref count));
		Assert.Equal(0, count);
		// this call initiates the observable pipeline, but does not
		// wait until the entire pipeline has been executed before
		// returning control to the caller
		// the question is: why? Rx knows I'm instigating an async task
		// as part of the pipeline (that's the point of the FromAsync
		// method), so why can't it still treat the pipeline atomically
		// when I call Start() on the scheduler?
		scheduler.Start();
		// count is still zero at this point
		Assert.Equal(1, count);
	}
	private async Task<Unit> Whatever(IScheduler scheduler)
	{
		return await Observable.Timer(TimeSpan.FromMilliseconds(100), scheduler).Select(_=>Unit.Default).ToTask();
	}
