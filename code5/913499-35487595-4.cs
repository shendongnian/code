    public static bool Method(string name, int age)
    {
    	...
    }
    var method = (Func<string, int, bool>)Method;
	Foo<bool>(method, "Jon", 40);
