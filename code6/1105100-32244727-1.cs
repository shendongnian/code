    private static void Main(string[] args)
    {
		var attribute = typeof(MyClass).GetCustomAttribute<MyAttribute>();
		Console.WriteLine(attribute == null ? "missing" : "exists");
	}
