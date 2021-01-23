    void Foo(params object[] objects)
    {
        var entries = new List<object>();
        foreach(var o in objects)
        {
            entries.Add(o);
        }
        ...
    }
