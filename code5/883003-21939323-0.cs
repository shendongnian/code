    var queryList = messages
        .Where(t => System.Data.Entity.DbFunctions.TruncateTime(t.LogTimeStamp) >= fromDate)
        .Where(t => System.Data.Entity.DbFunctions.TruncateTime(t.LogTimeStamp) <= toDate)
        .Where(t => t.LogType != stateInfoNoAuditFile)
        .OrderBy(m => m.LogID)
        .ToList();
        if (queryList.Any())
        {
            ....
            queryList.Count()....
            ....
        }
