    var query = new[] { 1, 2, 3 }
        .AsQueryable()
        .Where(x => x > EfUtil.ResultOf(Math.Max(1, 2)))
        .EvaluateResults();
    Console.WriteLine(query.ToString());
