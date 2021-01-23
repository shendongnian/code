	void Main()
	{
		Random r = new Random();
		List<int> list = Enumerable.Range(1,Int16.MaxValue)
                                   .Select (e => r.Next(0,Int16.MaxValue))
                                   .ToList();
		
		// Firts attempt with a non empty collection
		MethodToTest(new Collection<int>(list));
	
		// Second attempt with an empty collection
		MethodToTest(new Collection<int>());
	}
	
	// Define other methods and classes here
	public void MethodToTest(Collection<int> collection)
	{
		var sum = collection.Sum (i => i);
		// do something with it. If you're just voiding it and it doesn't get 
		// used, it might be removed by compiler.
	}
