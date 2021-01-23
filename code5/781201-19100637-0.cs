    var list = new List<int>(1) { 3 };
    using (var e = list.GetEnumerator())
    {
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    
        Reset(ref e);
    
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    }
    static void Reset<T>(ref T enumerator) where T : IEnumerator
    {
        enumerator.Reset();
    }
