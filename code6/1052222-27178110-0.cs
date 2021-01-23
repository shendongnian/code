    var downModelList = context.Data
        .OrderByDescending(d => d.Count)
        .Take(10)
        .Select(d => new
        {
            Name = d.Name,
            Count = d.Count
        })
        .Concat(context.Data
            .OrderByDescending(d => d.Count)
            .Skip(10)
            .Select(d => new
            {
                Name = "Others",
                Count = d.Count
            }))
        .GroupBy(x => x.Name)
        .Select(g => new downModel
        {
            modelName = g.Key,
            count = g.Sum(x => x.Count)
        })
        .ToList();
