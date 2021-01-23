    var lowerBound = new TimeSpan(0, 12, 0, 0);
    var upperBound = new TimeSpan(0, 18, 0, 0);
    var query = session.QueryOver<HistoryData>()
        .WhereRestrictionOn(c => c.HD_TIME)
            .IsBetween(lowerBound)
            .And(upperBound)
        ...
        .Take(10) // paging
        .Skip(10)
        ;
    var result = query.List<HistoryData>();
