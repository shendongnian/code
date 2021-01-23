    var groupedData = db2.ReturerDB.GroupBy(r => new { r.Date.Year, r.Date.Month })
                 .Select(g => new { g.Key.Year, g.Key.Month, Count = g.Count() })
                 .OrderBy(x => x.Year).ThenBy(x => x.Month);
                 .ToList();
    var result = groupedData
                 .ToDictionary(g => string.Format("{0}-{1:00}", g.Year, g.Month),
                               g => g.Count);
