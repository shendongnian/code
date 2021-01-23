    private static void RunTest(Type type)
    {
        Console.WriteLine(type.Name);
        Console.WriteLine();
        dynamic obj = Activator.CreateInstance(type);
        int i = obj.NewProp;
        Console.WriteLine(i);
        obj.NewProp = 123;
        i = obj.NewProp;
        Console.WriteLine(i);
        Console.WriteLine();
    }
