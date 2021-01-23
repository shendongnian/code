    void Main()
    {
    	Console.WriteLine ("Calling with string:");
    	object type = GetByType<string>("0");
    	Console.WriteLine (type.GetType());
    	
    	Console.WriteLine ("Calling with boolean:");
    	type = GetByType<bool>("0");
    	Console.WriteLine (type.GetType());
    	
    	Console.WriteLine ("Calling with integer:");
    	type = GetByType<int>("0");
    	Console.WriteLine (type.GetType());
    	
    	Console.WriteLine ("Calling with DateTime:");
    	type = GetByType<DateTime>("0");
    	Console.WriteLine (type.GetType());
    }
