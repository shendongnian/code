    var list = new List<int>(1) { 3 };
    var e = list.GetEnumerator();
    // Can't use "ref" with a using statement
    try
    {
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    
        Reset(ref e);
    
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    }
    finally
    {
        e.Dispose();
    }
    static void Reset<T>(ref T enumerator) where T : IEnumerator
    {
        enumerator.Reset();
    }
