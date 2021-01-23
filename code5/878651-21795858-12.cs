	// declare delegate contract
	private delegate void output();
	// create caller method
	private void method(output fun)
	{
		fun();
	}
	// some test functions, that must match exactly the delegate description
	// return type and number of arguments
	private void test1()
	{
		Console.WriteLine("1");
	}
	
	private void test2()
	{
		Console.WriteLine(DateTime.Now.ToString());
	}
	// call different methods
	method(test1);
	method(test2);
