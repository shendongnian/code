    var groups1 = List1
        .GroupBy(c => new { c.Firstname, c.LastName, c.IsAdmin });
    var groups2 = List2
        .GroupBy(c => new { c.Firstname, c.LastName, c.IsAdmin });
    var diffs = from g1 in groups1
                join g2 in groups2
                on g1.Key equals g2.Key into gj
                from g2 in gj.DefaultIfEmpty(Enumerable.Empty<Contact>())
                where g1.Count() > g2.Count()
                select new { g1, g2 };
    List<Contact> allDiffs = diffs
        .SelectMany(x => x.g1.Take(x.g1.Count() - x.g2.Count()))
        .ToList();
