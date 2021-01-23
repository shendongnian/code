    foreach (var res in Columns.GroupBy(c => new { c.LocId, c.SecId })
                               .Select(g => new
                               {
                                   g.Key.LocId,
                                   g.Key.SecId,
                                   MinStartElevation = g.Min(c => c.StartElevation),
                                   MaxEndElevation = g.Max(c => c.EndElevation)
                               }))
    {
        Console.WriteLine("LocId = {0}, SecId = {1}, MinStartElevation = {2}, MaxEndElevation = {3}",
            res.LocId, res.SecId, res.MinStartElevation, res.MinStartElevation);
    }
