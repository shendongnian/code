    var idCounts = dt.AsEnumerable()
        .GroupBy(row => row.Field<int>("ID"))
        .Select(g => new
        {
            EventID = g.Key,
            Count = g.Count()
        })
        .ToList();
    listBox.DataSource = idCounts;
