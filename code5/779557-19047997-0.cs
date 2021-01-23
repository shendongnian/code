    var grouped =
        from e in Events
        group e by e.Starts.Date into g
        let first = g.First()
        select new
        {
            Date = g.Key,
            Events = from e in g
                     group e by e.Name into g2
                     select new
                     {
                          Name = g2.Key,
                          Time = string.Join(", ", g2.Select(e2 => e2.Starts.ToString("hh:mm tt")))
                     }
        };
