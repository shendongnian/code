    var dt1 = new Dictionary<string, int> { { "Test1", 1 }, { "Test2", 1 }, { "Test3", 1 } };
    var dt2 = new Dictionary<string, int> { { "Test11", 101 }, { "Test22", 201 }, { "Test33", 301 } };
    
    var dt3 = new Dictionary<int, Dictionary<string, int>> { { 11, dt1 }, { 22, dt2 } };
    
    foreach (var kvp in dt3)
    {
        var innerDict = kvp.Value;
    
        foreach (var innerKvp in innerDict)
        {
             Console.WriteLine(kvp.Key);
             Console.WriteLine(innerKvp.Key);
             Console.WriteLine(innerKvp.Value);
        }
    }
