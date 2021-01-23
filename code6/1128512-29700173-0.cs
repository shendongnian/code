     var hourGroups = dataTable.AsEnumerable()
        .Select(row => new { DateAndTime = row.Field<DateTime>("dateAndTime"), Row = row })
        .GroupBy(x => new { Date = x.DateAndTime.Date, Hour = x.DateAndTime.Date.Hour });
    foreach (var x in hourGroups)
        Console.WriteLine("Date: {0} Hour: {1}: Count: {2} All names: {3}", 
            x.Key.Date.ToShortDateString(),
            x.Key.Hour,
            x.Count(),
            string.Join(",", x.Select(xx => xx.Row.Field<string>("name")))); // just bonus
