      var thisYearPairs = from m in Enumerable.Range(1, DateTime.Now.Month)
                          select new { Year = DateTime.Now.Year, Month = m };
      var lastYearPairs = from m in Enumerable.Range(DateTime.Now.Month, 12 - DateTime.Now.Month + 1)
                          select new { Year = DateTime.Now.Year - 1, Month = m };
      var ymOuter = from ym in thisYearPairs.Union(lastYearPairs)
                    join l in list on new { ym.Year, ym.Month } equals new { l.Year, l.Month } into oj
                    from p in oj.DefaultIfEmpty()
                    select new { a = ym, b = p == null ? DateTime.MinValue : p };
      var ymGroup = from ym in ymOuter
                    group ym by ym into g
                    select new { GroupCriteria = g.Key.a, Count = g.Key.b == DateTime.MinValue ? 0 : g.Count() };
