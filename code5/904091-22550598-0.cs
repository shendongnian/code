	public void NoReturnValue()
	{
		// It doesn't matter what happens in here; the caller won't get a return value!
	}
	
	public int IntReturnValue()
	{
		// Tons of code here, or none; it doesn't matter
		return 0;
	}
	
	...
	
	NoReturnValue(); // Can't use the return value because there is none!
	int i = IntReturnValue(); // The method says it returns int, so the compiler likes this
