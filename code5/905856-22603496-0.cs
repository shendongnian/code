    void Main()
    {
    	int x = 42;
    
    if (x.Equals(x = Foo())) //This is always true.
        Console.WriteLine(x); //0
        Console.WriteLine("ok");
    }
    
    int Foo()
    {
    	return 0;
    }
