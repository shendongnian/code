    private static object GetPageUsers(IEnumerable<Pagehit> getPageLog)
    {
        return getPageLog
              .GroupBy(g => g.UserID)
              .Select(x => new { User = GetUserFName(x.Key.ToString()),
                                 NumberOfHits = x.Count(),
                                 percentage = (100 * x.Count()) / getPageLog.Count() + "%"
              })
              .OrderByDescending(o => o.NumberOfHits);
    }
