    void Foo(params IEntry[] objects)
    {
        var entries = new List<IEntry>();
        foreach(var o in objects)
        {
            entries.Add(o);
        }
        ...
    }
