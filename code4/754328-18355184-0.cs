    var qry = s.Videos
    .GroupBy(v => new { v.Name })
    .Select(g => new
    {
        g.Key.Name,
        TotalVideoHours = g.Sum(c => EntityFunctions.DiffHours(c.RecordingStarted, c.RecordingEnded))
    });
