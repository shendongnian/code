    var dupes = people.GroupBy(e => new { e.FirstName, e.LastName })
        .Where(e => e.Count() > 1)
        .Select(e => new
        {
            e.Key.FirstName,
            e.Key.LastName,
            Entities = e.ToList()
        });
