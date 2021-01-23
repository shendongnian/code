    List<string> strings = new List<string>()
    {
        "Customers\\Order1",
        "Customers\\Order10",
        "Customers\\Order1\\Product1",
        "Customers\\Order2\\Product1",
        "Customers\\Order2\\Product1\\Price"
    };
    foreach (var result in strings.DistinctBySubString())
    {
        Console.WriteLine(result);
    }
