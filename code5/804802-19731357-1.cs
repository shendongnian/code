    from b in bands
    group b by new { b.Region, b.DayName } into g
    select new {
       g.Key.Region,
       g.Key.DayName,
       StartDate = g.Min(x => x.StartDate),
       EndDate = g.Max(x => x.EndDate),
       AllBandsFromGroup = g,
       FirstBand = g.First(),
       LastBandPeriod = g.Last().Period
    }
