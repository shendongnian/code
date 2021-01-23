	public IObservable<Either<TResult, Exception>> Poll<TResult, TArg>(
	    Func<TArg, IObservable<TResult>> asyncFunction,
	    Func<TArg> parameterFactory,
	    TimeSpan interval,
	    IScheduler scheduler)
	{
	    return Observable.Create<Either<TResult, Exception>>(observer =>
	    {
	        return scheduler.ScheduleAsync(async (ctrl, ct) => {
	            while(!ct.IsCancellationRequested)
	            {
	                try
	                {
	                    var result = await asyncFunction(parameterFactory());
	                    observer.OnNext(Either.Right<TResult, Exception>(result));
	                }
	                catch(Exception ex)
	                {
	                    observer.OnNext(Either.Left<TResult, Exception>(ex));
	                }
	                await ctrl.Sleep(interval, ct);
	            }
	        });        
	    });    
	}
