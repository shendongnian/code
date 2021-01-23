    public void Foo()
    {
        object x = new object();
        // The object can't be collected here...
        Console.WriteLine(x);
        // But it *can* be collected here
        Console.WriteLine("This line doesn't depend on x");
    }
