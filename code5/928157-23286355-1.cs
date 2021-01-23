	public void YourServiceMethod()
	{
		var collection = GetSomeDate();
		collection.DoWork(item => PerformSomeOperation(someParameters));
	}
	public class ListExtensions
	{
		public void DoWork(this List<SomeType> collection, Action<SomeType> itemProcessor)
		{
		   var exceptions = new List<Exception>();
			foreach (var item in collection) 
			{
				try 
				{
					itemProcessor(someParameters);
				}
				catch (Exception exception) 
				{
					exceptions.Add(exception);
				}
			}
			// Throw the exceptions here after the loop completes. 
			if (exceptions.Count > 0) throw new AggregateException(exceptions);
		}
	}
