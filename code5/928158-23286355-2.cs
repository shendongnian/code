	public void YourServiceMethod()
	{
		var collection = GetSomeDate();
		collection.ProcessList(item => PerformSomeOperation(someParameters));
	}
	public class ListExtensions
	{
		public void ProcessList<T>(this IEnumerable<T> collection, Action<T> itemProcessor)
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
