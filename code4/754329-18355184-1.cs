    var qry = s.Videos
    .GroupBy(v => new { v.Name })
    .Select(g => new
    {
        g.Key.Name,
        TotalVideoHours = g.Sum(c => SqlFunctions.DateDiff("s", c.RecordingStarted, c.RecordingEnded) / 3600.0)
    });
