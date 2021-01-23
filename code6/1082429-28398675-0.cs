    var results =
    (
        // Use from, from like so for the left join:
        from a in dc.Table1
        from e in dc.Table2
            // Join condition goes here
            .Where(a.Id == e.Id)
            // This is for the left join
            .DefaultIfEmpty()
        // Non-join conditions here
        where a.Id == id
        // Then group
        group by new
        {
            a.Field1,
            a.Field2
        }
    ).Select(g =>
        // Sort items within groups
        g.OrderBy(item => item.sortField)
        // Project required data only from each item
        .Select(item => new
        {
            item.FieldA,
            item.FieldB
        }))
    // Bring into memory
    .ToList();
