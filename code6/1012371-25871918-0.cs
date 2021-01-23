	// no TestMethod attribute here
	public Task TestMyWebMethodAsync() 
	{
		return Task.Run(() => 
		  {
			// add testing code here
			
			Assert.AreEqual(expectedValue, actualValue);
		  });                
	}
	[TestMethod]
	public async void ParallelTest() 
	{
		try {
			const int TaskCount = 5;
			var tasks = new Task[TaskCount];
			for (int i = 0; i < TaskCount; i++) 
			{
				tasks[i] = TestMyWebMethodAsync();
			}
			
			await Task.WhenAll(tasks);
			
        // handle or rethrow the exceptions
		} catch (AssertionFailedException exc) {
			Assert.Fail("Failed!");
		} catch (Exception genericExc) {
			Assert.Fail("Exception!");
		}
	}
