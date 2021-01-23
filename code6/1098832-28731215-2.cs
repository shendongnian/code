    void DoSomething(object x)
    {
        Call((dynamic) x);
    }
    
    void Call(IList items)
    {
        Console.WriteLine("Swizzle");
    }
    
    void Call(object item)
    {
        Console.WriteLine("Wibble");
    }
