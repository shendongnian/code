    var list = new List<int>(1) { 3 };
    using (IEnumerator e = list.GetEnumerator())
    {
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    
        e.Reset();
    
        Console.WriteLine(e.MoveNext());
        Console.WriteLine(e.Current);
    }
