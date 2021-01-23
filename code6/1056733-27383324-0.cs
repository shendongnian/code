    var statistics = observableDurations
        .GroupBy(d => d.Latency > 10)
        .Select(g =>
        {
            var seed = new
            {
                Type = g.Key ? "A" : "B",
                Min = Double.MaxValue,
                Max = Double.MinValue,
                Average = 0.0,
                Count = 0
            };
            return g.Aggregate(seed, (total, duration) => new
            {
                Type = total.Type,
                Min = Math.Min(total.Min, duration.Latency),
                Max = Math.Max(total.Max, duration.Latency),
                Average = (total.Average * total.Count + duration.Latency) / (total.Count + 1),
                Count = total.Count + 1
            });
        });
