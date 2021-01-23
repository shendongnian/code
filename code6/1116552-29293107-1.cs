    var dataAsList = (from n in db.Samples.Where(n => n.Type == "weight").AsEnumerable()
    group n by new { Date = n.SampleTime.Date, Hour = n.SampleTime.Hour } into g
    select new 
    {
        dategrouping = g.Date,
        hourgrouping = g.Hour,
        average = g.Average(a => a.Quantity),
        max = g.Max(a => a.Quantity),
        min = g.Min(a => a.Quantity),
        count = g.Count()
    }).ToList();
 
