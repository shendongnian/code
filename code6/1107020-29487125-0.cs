    public static Func<BlacklistDataContext, DateTime, DateTime, IEnumerable<BlacklistEntry>>
        GetBlacklistEntriesByBlacklistDateRangeFunc =
            CompiledQuery.Compile<BlacklistDataContext, DateTime, DateTime, List<BlacklistEntry>>(
                (db, startTime, endTime) =>
                    from BlacklistEntry e in db.BlacklistEntries
                    where e.BlacklistDate >= startTime && e.BlacklistDate <= endTime
                    select e);
