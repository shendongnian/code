    void Main()
    {
        var points = new[]
        {
            new { dt = new DateTime(2012, 1, 1, 23, 53, 00), value = 5 },
            new { dt = new DateTime(2012, 1, 1, 23, 54, 00), value = 2 },
            new { dt = new DateTime(2012, 1, 1, 23, 55, 00), value = 1 },
            new { dt = new DateTime(2012, 1, 1, 23, 56, 00), value = 3 },
            new { dt = new DateTime(2012, 1, 1, 23, 57, 00), value = 4 },
            new { dt = new DateTime(2012, 1, 1, 23, 58, 00), value = 5 },
            new { dt = new DateTime(2012, 1, 1, 23, 59, 00), value = 6 },
            new { dt = new DateTime(2012, 1, 2, 00, 00, 00), value = 2 },
            new { dt = new DateTime(2012, 1, 2, 00, 01, 00), value = 4 },
            new { dt = new DateTime(2012, 1, 2, 00, 01, 00), value = 5 }
        };
    
        var interval = TimeSpan.FromMinutes(5);
        var averageByInterval =
            from point in points
            let intervalStart = new DateTime(((int)((point.dt.Ticks + interval.Ticks / 2) / interval.Ticks)) * interval.Ticks)
            group point.value by intervalStart into g
            select new { g.Key, average = g.Average() };
        averageByInterval.Dump();
    }
