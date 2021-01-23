	static void Main(string[] args)
	{
		var repository = new MyRepository(connectionString);
		var data = repository.GetLotsOfData(ProcessData);
	}
	public static IEnumerable<ResultObject> ProcessData(IEnumerable<MyMapObject> data)
	{
		foreach (var record in data)
		{
			var result = new ResultObject();
			//do some work...
			yield return result;
		}
	}
