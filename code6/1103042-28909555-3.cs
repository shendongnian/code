	public static class NonGenericStaticClass
	{
		// The JIT Compiler might rename these methods after their
		// representative types to avoid any weird overload issues, but I'm not sure
		public static string GenericMethod(Int32 value)
		{
			// Note that the JIT Compiler might optimize much of this away
			// since the first 2 "if" statements are always going to be false
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
				return string.Format("It's a {0}!", typeof(Int32).Name);
			}
		}
		
		public static string GenericMethod(Foo value)
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
				return string.Format("It's a {0}!", typeof(Foo).Name);
			}
		}
	}
	
	// ...
	
	static void Main()
	{
		// Notice how we don't need to specify the type parameters any more.
        // (of course you could've used generic inference, but that's beside the point),
		// That is because they are essentially, but not necessarily, overloads of each other
	
		// Prints "It's a Int32!"
		Console.WriteLine(NonGenericStaticClass.GenericMethod(100));
		
		// Prints "Foo"
		Console.WriteLine(NonGenericStaticClass.GenericMethod(new Foo()))
		
		// Prints "It's a Int32!"
		Console.WriteLine(NonGenericStaticClass.GenericMethod(20));
	}
