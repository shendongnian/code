    var groups1 = List1
        .GroupBy(c => new { c.Firstname, c.LastName, c.IsAdmin });
    var groups2 = List2
        .GroupBy(c => new { c.Firstname, c.LastName, c.IsAdmin });
    var diffs = from g1 in groups1
                join g2 in groups2
                on g1.Key equals g2.Key into gj
                from g2Nullable in gj.DefaultIfEmpty()
                where g2Nullable == null || g1.Count() > g2Nullable.Count()
                select new { g1, g2Nullable };
    List<Contact> allDiffs = diffs
        .SelectMany(x => x.g1.Take(x.g1.Count() - x.g2Nullable == null ? 0 : x.g2Nullable.Count()))
        .ToList();
