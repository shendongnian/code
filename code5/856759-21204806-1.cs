	var query =
		Observable
			.Create<int>(o =>
				Scheduler.Default.AsLongRunning().ScheduleLongRunning(c =>
				{
					for (var i = 0; i < 100; i++)
					{
						Thread.Sleep(100);
						if (c.IsDisposed)
						{
							break;
						}
					}
					if (!c.IsDisposed)
					{
						o.OnNext(42);
					}
					o.OnCompleted();
				}))
			.Timeout(TimeSpan.FromMinutes(2.0));
