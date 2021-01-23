	public IObservable<Either<Exception, TResult>> Poll<TResult, TArg>(
	    Func<TArg, IObservable<TResult>> asyncFunction,
	    Func<TArg> parameterFactory,
	    TimeSpan interval,
	    IScheduler scheduler)
	{
	    return Observable.Create<Either<Exception, TResult>>(observer =>
	    {
	        return scheduler.ScheduleAsync(async (ctrl, ct) => {
	            while(!ct.IsCancellationRequested)
	            {
	                try
	                {
	                    var result = await asyncFunction(parameterFactory());
	                    observer.OnNext(Either.Right<Exception,TResult>(result));
	                }
	                catch(Exception ex)
	                {
	                    observer.OnNext(Either.Left<Exception, TResult>(ex));
	                }
	                await ctrl.Sleep(interval, ct);
	            }
	        });        
	    });    
	}
