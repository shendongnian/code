    GolfitoDataContext db = new GolfitoDataContext();
    var dic = db.GetTable<History>()
            .Select(p => new { p.Title, p.Date }).Where(x => x.Date >= startDateFilter && x.Date <= endDateFilter)
            .DistinctBy(p => p.Title)
            .AsEnumerable()
            .ToDictionary(k => k.Title, v => v.Date);     
