	public class MyObject : IDisposable
	{
		private T CurrentT;
		private IDisposable Subscription;
		public MyObject(IObservable<T> externalSource) 
		{
			Subscription = externalSource
				.Subscribe((t) => { CurrentT = t; });
		}
		
		public void Dispose()
		{
			Subscription.Dispose();
		}
		
		public void DoSomething()
		{
			DoSomethingWith(CurrentT);
		}
	}
