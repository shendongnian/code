	[TestMethod]
	public void MyTestMethod()
	{
		var dummyA = TestA();
		var dummyB = TestB();
	
		var realA = 0L;
		var realB = 0L;
		for (var i = 0; i < 10; i++)
		{
			realA += TestA();
			realB += TestB();
		}
		
		Console.WriteLine("TESTA: " + realA.ToString());
		Console.WriteLine("TESTB: " + realA.ToString());
	}
