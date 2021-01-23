    var result = dt.AsEnumerable()
        .GroupAdjacent(r => r.Field<string>("State"))
        .Where(g => g.Key == "NY")
        .Select(g => new{ Min=g.Min(r => r.Field<int>("Id")), Max=g.Max(r => r.Field<int>("Id")) })
        .ToList();
    foreach (var x in result)
        Console.WriteLine("Min={0} Max={1}", x.Min, x.Max);   
    // Min=2 Max=5
    // Min=8 Max=9
 
