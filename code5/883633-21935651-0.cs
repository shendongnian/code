	public void Main()
	{
	   Test(x => Debug.Write(x));
	}
	private void Test(Action<string> testAction)
	{
	   testAction("Bla");
	}
