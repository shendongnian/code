    var participantsWithBestResults = db.Participantes.Where(x => x.Results.Any(y => y.valid > 0))
    .Select(x => new
    {
        user = x,
        bestResult = x.Results.Where(y => y.valid > 0)
            .GroupBy(y => y.type)
            .Select(y => new
            {
                type = y.First().type,
                count = y.Count()
            })
            .OrderByDescending(y => y.count)
            .FirstOrDefault()
    });
