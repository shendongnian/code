	public void ThisTestWillNeverFail()
	{
		try
		{
			Assert.Fail("some error message");
		}
		catch (Exception) 
		{
		} 
	}
