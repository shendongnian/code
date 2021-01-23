    var items = new TextFileLineBuffer(filename);
    DoSomething(items);
    void DoSomething(IEnumerable<string> list)
    {
        foreach (var s in list)
            Console.WriteLine(s);
    }
