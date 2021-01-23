    for (int i = 0; i < UniqueNumbers.Count / 5; i++)
    {
        // Gets the next 5 numbers
        var group = UniqueNumbers.Skip(i * 5).Take(5);
        // Convert the numbers to strings
        var stringNumbers = group.Select(n => n.ToString()).ToList();
        // Pass the numbers into the method
        var q = new SolrQueryInList(stringNumbers[0], stringNumbers[1], ...
    }
