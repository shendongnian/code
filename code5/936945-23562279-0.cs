    var orderedByAsc = input.OrderBy(d => d);
    if (input.SequenceEqual(orderedByAsc))
    {
        Console.WriteLine("Ordered by Asc");
        return;
    }
    
    var orderedByDsc = input.OrderByDescending(d => d);
    if (input.SequenceEqual(orderedByDsc))
    {
        Console.WriteLine("Ordered by Dsc");
        return;
    }
    
    Console.WriteLine("not sorted");
