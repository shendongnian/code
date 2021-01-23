    DailyStatistics
    .Join
    (
        DailyStatistics,
        x=>new{x.EntryDate, x.SiteID},
        x=>new{x.EntryDate, x.SiteID},
        (o,i)=>new 
        {
            VisitorEntry=i.Metric,
            VisitEntry=o.Metric,
            VisitorDate = i.EntryDate ,
            VisitDate = o.EntryDate ,
            i.SiteID,
            VisitorValue = i.Value,
            VisitValue = o.Value
        }
    )
    .GroupBy
    (
        x=>
        new
        {
            x.SiteID,
            x.VisitDate
        }
    )
    .Select
    (
        x=>
        new
        {
            x.Key.SiteID, 
            x.Key.VisitDate, 
            SumVisits = s.Sum(t => t.VisitValue ), 
            SumVisitors = s.Sum(x => x.VisitorValue ) 
        }
    )
    .OrderBy
    (
        x=>x.VisitDate
    )
