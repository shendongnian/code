    A.MyName = "hello";
    Console.WriteLine(B.MyName); // hello
    foreach(var type in new[] { typeof(A), typeof(B) })
    {
        var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy;
        var property = type.GetProperty("MyName", flags);
        Console.WriteLine(property.GetValue(null));
    }
