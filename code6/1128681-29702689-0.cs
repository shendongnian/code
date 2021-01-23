    public static IEnumerable<int> Foo()
    {
        Console.WriteLine("Returning 1");
        yield return 1;
        Console.WriteLine("Returning 2");
        yield return 2;
        Console.WriteLine("Returning 3");
        yield return 3;
    }
