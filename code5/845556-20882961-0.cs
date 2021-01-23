    var sums = Prices.Select(i => new { ColSum= i.Price1 + i.Price2 + i.Price3 + i.Price4 });
    
    foreach (var sum in sums)
    {
        Console.WriteLine(sum.ColSum.ToString());
    }
