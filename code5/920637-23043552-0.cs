    Assembly myAssembly = Assembly.GetExecutingAssembly();
    foreach (Type type in myAssembly.GetTypes())
    {
        Console.WriteLine(type.FullName);
    }
