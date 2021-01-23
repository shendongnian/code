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
    .Where
    (
        x=>
        x.VisitorEntry == "MyVisitors" &&
        x.VisitEntry== "MyVisits" &&
        x.VisitDate >= DateTime.Parse("2013-08-15")  &&
        x.VisitDate <= DateTime.Parse("2013-08-21")
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
