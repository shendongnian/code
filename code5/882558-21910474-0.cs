	/// <summary>
	/// Pass the head and tail of the observable to the
	/// selector function. Note that 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="U"></typeparam>
	/// <param name="source"></param>
	/// <param name="fn"></param>
	/// <returns></returns>
	public static IObservable<U> HeadTailSelect<T, U>
	    (this IObservable<T> source, Func<T, IObservable<T>, U> fn)
	{
	    var tail = new Subject<T>();
	    return Observable.Create<U>(observer =>
	    {
	        return source.Subscribe(v =>
	        {
	            tail.OnNext(v);
	            var u = fn(v, tail);
	            observer.OnNext(u);
	            
	        }
	        ,e=> { tail.OnCompleted();observer.OnError(e);  }
	        ,()=> { tail.OnCompleted();observer.OnCompleted();  });
	    });
	}
	
