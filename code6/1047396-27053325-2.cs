	class Worker
	{
		private Random _r = new Random();
		private IDisposable _subscription = null;
		
		public void doWork()
		{
			_subscription =
				Observable
					.Range(0, 4, Scheduler.Default)
					.Select(n =>
						Observable
							.Generate(
								0, x => true, x => x, x => x,
								x => TimeSpan.FromMilliseconds(_r.Next(500, 1000)),
								Scheduler.Default)
							.Select(x => n))
					.Merge()
					.Subscribe(i => method(i));
		}
	
	
		public void HardStop()
		{
			_subscription.Dispose();
		}
	}
