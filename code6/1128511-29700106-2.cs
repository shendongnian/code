    var query = dt.AsEnumerable()
        .GroupBy(row => new
        {
            Date = row.Field<DateTime>("dateAndTime").Date, 
            Hour = row.Field<DateTime>("dateAndTime").Hour
        })
        .Select(grp => new
        {
            Date = grp.Key.Date,
            Hour = grp.Key.Hour,
            Count = grp.Count()
        });
