    List<Person> smallFlattened = groups.Where(x => x.Count() <= 4)
        .SelectMany(p => p).ToList();
    IEnumerable<List<Person>> groupPersonLists = groups
        .Where(g => g.Count() > 4)
        .Select(g => g.ToList())
        .Concat(new[] { smallFlattened });
