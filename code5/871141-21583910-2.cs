    var remaining = UniqueNumbers;
    while(remaining.Any())
    {
        // Gets the next 5 numbers
        var group = remaining.Take(5);
        // Convert the numbers to strings
        var stringNumbers = group.Select(n => n.ToString()).ToList();
        // Pass the numbers into the method
        var q = new SolrQueryInList(stringNumbers[0], stringNumbers[1], ...
        // Update the starting spot
        remaining = remaining.Skip(5);
    }
