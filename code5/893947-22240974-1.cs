	public class MyObject
	{
		private T CurrentT;
		public IDisposable Observe(IObservable<T> externalSource) 
		{
			return externalSource
				.Subscribe((t) => { CurrentT = t; });
		}
		
		public void DoSomething()
		{
			DoSomethingWith(CurrentT);
		}
	}
