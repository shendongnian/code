    public static IObservable<TSource> RetryWithDelay<TSource, TException>(this IObservable<TSource> source, Func<TException, int, TimeSpan> delayFactory)
		where TException : Exception
	{
		var disposable = new SerialDisposable();
	
		return Observable.Create<TSource>(observer =>
		{
			int retryCount = 0;
			
			var scheduleDisposable = Scheduler.CurrentThread.Schedule(TimeSpan.Zero,
			self =>
			{
				var subscription = source.Subscribe(
				observer.OnNext,
				ex =>
				{
					var typedException = ex as TException;
					if (typedException != null)
					{
						var retryDelay = delayFactory(typedException, ++retryCount);
						self(retryDelay);
					}
					else
					{
						observer.OnError(ex);
					}
				},
				observer.OnCompleted);
				
				disposable.Disposable = subscription;
			});
			
			return new CompositeDisposable(scheduleDisposable, disposable);
		});
	}
