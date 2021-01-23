	public static class NonGenericStaticClass
	{
		public static string GenericMethod<T>(T value)
		{
			if(value is Foo)
			{
				return "Foo";
			}
			else if(value is Bar)
			{
				return "Bar";
			}
			else
			{
				return string.Format("It's a {0}!", typeof(T).Name);
			}
		}
	}
	
	// ...
	
	static void Main()
	{
		// Prints "It's a Int32!"
		Console.WriteLine(NonGenericStaticClass.GenericMethod<int>(100));
		
		// Prints "Foo"
		Console.WriteLine(NonGenericStaticClass.GenericMethod<Foo>(new Foo()))
		
		// Prints "It's a Int32!"
		Console.WriteLine(NonGenericStaticClass.GenericMethod<int>(20));
	}
