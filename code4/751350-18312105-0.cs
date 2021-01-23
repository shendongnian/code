	public static class ObservableEx
	{
		public static IObservable<T> Initially<T>(this IObservable<T> source, Action onSubscribe)
		{
			return Observable.Create<T>(o=>{
				try
				{	        
					onSubscribe();
					return source.Subscribe(o);
				}
				catch (Exception ex)
				{
					o.OnError(ex);
					return Disposable.Empty;
				}
			});
		}
	}
