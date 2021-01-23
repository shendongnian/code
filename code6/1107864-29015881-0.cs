    var res = Enumerable.Range(1, 6)
        .SelectMany(v => TrackingInfo.Where(info => info.EmailActions.Contains(v)).Select(info => new { Id, Value = v }))
        .GroupBy(p => p.Value)
        .Select(g => new {
            Id = g.Key
        ,   Values = g.Select(p => p.Id).ToList()
        });
