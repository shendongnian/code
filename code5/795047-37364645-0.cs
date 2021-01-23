    [TestCase("1, 2")]
    [TestCase("1, 2, 3")]
    public void WithStrings(string listString)
    {
        var list = listString.Split(',')
                             .Select(int.Parse)
                             .ToList();
        Console.WriteLine(string.Join(",", list));
    }
