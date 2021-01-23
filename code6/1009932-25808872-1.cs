    var list = new[]
    {
        "Joe", 
        "", 
        "Bill", 
        "Bill", 
        "", 
        "Scott", 
        "Joe", 
        "", 
        ""
    };
    foreach (var item in list.TrimEnd(string.IsNullOrEmpty))
    {
        Console.WriteLine(item);
    }
