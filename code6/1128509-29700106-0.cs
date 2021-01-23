    var query = dt.AsEnumerable()
        .GroupBy(row => row.Field<DateTime>("dateAndTime").Hour)
        .Select(grp => new
        {
            Hour = grp.Key,
            Count = grp.Count()
        });
