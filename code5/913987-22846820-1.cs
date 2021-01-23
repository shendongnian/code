    var distinctValues = test.AsEnumerable()
                            .GroupBy(r => r.Field<int>("Studios"))
                            .Select(grp => new
                            {
                                Studio = grp.Key,
                                Count = grp.Count(),
                            })
                            .ToList();
    foreach (var item in distinctValues)
    {
        Console.WriteLine("Studio : {0}, Number: {1}", item.Studio, item.Count);
    }
