    private static object GetPageUsers(IEnumerable<Pagehit> getPageLog)
    {
        return getPageLog
              .GroupBy(g => g.UserID)
              .Select(x => new { User = GetUserFName(x.Key.ToString()),
                                 NumberOfHits = x.Count(),
                                 percentage = x.Count() / getPageLog.Count() *100 + "%"
              })
              .OrderByDescending(o => o.NumberOfHits);
    }
