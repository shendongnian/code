    var distinctValues = test.AsEnumerable()
                            .GroupBy(r => r.Field<string>("Studios"))
                            .Select(grp => new
                            {
                                StudioName = grp.Key,
                                Count = grp.Count(),
                            })
                            .ToList();
    foreach (var item in distinctValues)
    {
        Console.WriteLine("Studio Name: {0}, Number: {1}", item.StudioName, item.Count);
    }
