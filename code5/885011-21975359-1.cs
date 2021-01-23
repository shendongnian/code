    public static Main()
    {
        Console.WriteLine("1- PerCall");
        Console.WriteLine("2- Session");
        Console.WriteLine("3- Single");
        Console.Write("Choose: ");
        var choice = Console.ReadLine();
   
        switch(choice)
        {
            case "1":
                PerCallExample();
                PerCallExample();
                break;
            case "2":
                PerSessionExample();
                PerSessionExample();
                break;
            case "3":
                var foo = Foo();
                SingleExample(foo);
                SingleExample(foo);
                break;
         
        }
    }
    void Call(Foo foo)
    {
        Console.WriteLine(foo1.GetNumber());
    }
    void PerCallExample()
    {
         Foo foo;
         foo = new Foo();
         Call(Foo foo);
         foo = new Foo();
         Call(Foo foo);
    }
    void PerSessionExample()
    {
         Foo foo = new Foo();
         Call(Foo foo);
         Call(Foo foo);
    }
    void SingleExample(foo)
    {
         Call(Foo foo);
         Call(Foo foo);
    }
