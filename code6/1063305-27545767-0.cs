    static void Main(string[] args)
    {
        var enumerable = Enum1();
        Console.WriteLine("Enum1 retrieved");
        var enum2 = Enum2(enumerable);
        Console.WriteLine("Enum2 called");
        foreach (var e in enum2)
        {
            Console.WriteLine(e);
        }
    }
    private static IEnumerable<string> Enum1()
    {
        Console.WriteLine("Enum1");
        yield return "foo";
    }
    private static IEnumerable<string> Enum2(IEnumerable<string> enumerable)
    {
        Console.WriteLine("Enum2");
        foreach (var s in enumerable)
        {
            yield return s;
        }
    }
