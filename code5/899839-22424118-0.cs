	interface IBar
	{
	}
	
	interface IFoo<T>
	{
		T Bar { get; }
	}
	
	class FooBar<T> : IFoo<T> where T : IBar
	{
		public T Bar
		{
			get { return default(T); }
		}
	}
