    // Declare and then populate the LINQ source.
    List<Column> columns = new List<Column>();
    var query =
        from column in columns
        group column by new {column.LocId, column.SecId} into g
        orderby g.Key.LocId, g.Key.SecId
        select new
        {
            LocId = g.Key.LocId,
            SecId = g.Key.SecId,
            Columns = g
        };
