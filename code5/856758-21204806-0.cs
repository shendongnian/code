	var query =
		Observable
			.Create<int>(o =>
			{
				var cancellation = new CancellationDisposable();
				var scheduled = Scheduler.Default.Schedule(() =>
				{
					for (var i = 0; i < 100; i++)
					{
						Thread.Sleep(100);
						if (cancellation.Token.IsCancellationRequested)
						{
							break;
						}
					}
					if (!cancellation.Token.IsCancellationRequested)
					{
						o.OnNext(42);
					}
					o.OnCompleted();
				});
				return new CompositeDisposable(cancellation, scheduled);
			})
			.Timeout(TimeSpan.FromMinutes(2.0));
