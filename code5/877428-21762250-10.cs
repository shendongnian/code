    var results =
        from thing in
            (from line in tableFileCSV.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None)
             let row = line.Split(',')
             select new
             {
                 Host = row[0],
                 Path = row[1] + row[3] + "</br>",
                 Date = row[2],
                 File = row[3] // <- Are you sure you want this to be null and not the file value?
             })
        group new { thing.Path, thing.Date, thing.File } by new { thing.Host } into g
        select new
        {
            Host = g.Key.Host,
            Path = g.Select(i => i.Path).Aggregate((a, b) => a + b),
            Date = g.Select(i => i.Date).FirstOrDefault(),
            File = "File",
        };
    // If you want to get a look at it.
    foreach (var item in results)
    {
        Console.WriteLine("{0} {1} {2} {3}", item.Host, item.Path, item.Date, item.File);
    }
