    var dic = db.GetTable<History>()
                .Select(p => new { p.Title, p.Date})
                .Where(x => x.Date >= startDateFilter && x.Date <= endDateFilter)
                .GroupBy(x => x.Title)
                .ToDictionary(g => g.Key, g.Select(x => x.Date).ToList());
