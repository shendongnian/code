    var participantsWithBestResults = db.Participantes.Where(x => x.Results.Any(y => y.valid > 0))
    .Select(x => new
    {
        user = x,
        bestResult = x.Results.Where(y => y.valid > 0)
            .GroupBy(y => y.type)
            .OrderByDescending(y => y.Count())
            .Select(y => new
            {
                type = y.Key,
                count = y.Count()
            })
            .FirstOrDefault()
    });
