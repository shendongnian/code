    Assembly mscorlib = typeof(int).Assembly;
    var hs = new SortedSet<string>();
    foreach (Type type in mscorlib.ExportedTypes)
    {
        hs.Add(type.Namespace);
    }
    foreach (string ns in hs)
    {
        Console.WriteLine(ns); 
    }
