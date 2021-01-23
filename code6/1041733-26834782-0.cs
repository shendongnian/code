    var changesPerYearAndMonth =
        from month in Enumerable.Range(0, 12)
        let key = new { Year = DateTime.Now.AddMonths(-month).Year, Month = DateTime.Now.AddMonths(-month).Month }
        join revision in list on key
                equals new
                {
                    revision.LocalTimeStamp.Year,
                    revision.LocalTimeStamp.Month
                } into g
        select new { GroupCriteria = key, Count = g.Count() };
