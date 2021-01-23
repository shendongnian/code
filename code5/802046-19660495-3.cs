    Console.WriteLine(A.MyName()); // Bob
    Console.WriteLine(B.MyName()); // Bob
    foreach(var type in new[] { typeof(A), typeof(B) })
    {
        var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
        var method = type.GetMethod("MyName", flags);
        Console.WriteLine(method.Invoke(null, null));
    }
