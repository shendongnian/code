    var searchTerms = Comparate.Split(' ');
    var results = inputs
        .GroupBy(sentence => sentence.Split(' '))
        .Where(grouping => searchTerms.Intersect(grouping.Key).Any())
        .OrderByDescending(grouping => grouping.Key.Count())
        .SelectMany(grouping => grouping);
