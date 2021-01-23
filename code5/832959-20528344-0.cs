    var types = Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => t.Namespace.StartsWith("Test.POS"));
    foreach (var t in types)
    {
        Console.WriteLine(t.Name);
    }
