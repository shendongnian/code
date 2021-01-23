    string[] inputs = 
    {
        "example1",
        "exammple2",
        "example3",
        "exammple4",
        "example4" 
    };
    foreach (var input in inputs)
    {    
        Console.WriteLine("{0}: {1}", input, Regex.IsMatch(input, @"[^m]m[^m]"));
    }
