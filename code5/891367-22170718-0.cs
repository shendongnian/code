    var currentPageHits = pageHits
        .GroupBy(x => x.Url)
        .Select(x => new 
        {
            LastEntry = x.OrderByDesc(y => y.TimeStamp).First(),
            NumberOfHits = x.Count(),
            Url = x.Key,
         })
        .Select(x => new
        {
            LastTimeStamp = x.LastEntry.TimeStamp,
            LastUser = x.LastEntry.User,
            x.NumberOfHits,
            x.User,
        })
