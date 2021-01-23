    var groups = myArray
        .GroupBy(x => x)
        .Select(g => new { Value = g.Key, Count = g.Count() })
        .OrderByDescending(g => g.Count)
        .ToList(); // materialize the query to avoid evaluating it twice below
    int maxCount = groups[0].Count; // throws IndexOutOfRangeException if myArray is empty
    IEnumerable<int> modes = groups
        .Where(g => g.Count == maxCount)
        .Select(g => g.Value);
