    public static void Test()
    {
        var array = new List<Int32> { 1, 2, 3, 4, 5 };
        IEnumerator<Int32> e = array.GetEnumerator(); // boxed here
        e.MoveNext();
        e.MoveNext();
        Console.WriteLine(e.Current); // 2
        Increment(e);
        Console.WriteLine(e.Current); // now it's 4
    }
    static void Increment(IEnumerator<Int32> e)
    {
        Console.WriteLine("Inside " + e.Current); // 2
        e.MoveNext();
        Console.WriteLine("Inside " + e.Current); // 3
        e.MoveNext();
        Console.WriteLine("Inside " + e.Current); // 4
    }
