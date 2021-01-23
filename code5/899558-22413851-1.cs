    static Foo()
    {
        // note that properties needs to be static too!
        foreach(var prop in properties)
        {
            ValidatedProperties.Add(prop.Name);
            Console.WriteLine(prop.Name);
        }
    }
    public Foo()
    {
        // regular constructor for creating an instance of Foo
    }
