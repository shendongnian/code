    var resultTicks = ticks.GroupBy(t => t.Data.Year + "-" + t.Data.Month + "-" + t.Data.Day + " " + t.Data.Hour + ":" + t.Data.Minute)
        .Select(t => new
            {
                Group = t.Key,
                FirstRecord = t.FirstOrDefault()
            })
        .ToList();
