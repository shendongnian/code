    foreach(var type in typeof(Uri).Assembly.GetTypes())
    {
        if (type.IsAbstract) continue;
        if (!Attribute.IsDefined(type, typeof(SerializableAttribute))) continue;
        if (!typeof(MarshalByRefObject).IsAssignableFrom(type)) continue;
        Console.WriteLine(type.FullName);
    }
