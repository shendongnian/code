	public static void Main()
	{
		string foo = "bar";
 
		// new scope
		{
			foo += "baz";
		}
 
		Console.WriteLine(foo);
	}
