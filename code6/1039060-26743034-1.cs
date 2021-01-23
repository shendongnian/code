    static Dictionary<string, MyItem> GetLatestCodes(
        IEnumerable<MyItem> items, DateTime latestAllowableTimestamp)
    {
        return items
            .Where(item => item.TimeStamp <= latestAllowableTimestamp)
            .GroupBy(item => item.Code)
            .Select(group => group
                .OrderByDescending(item => item.TimeStamp)
                .First())
            .ToDictionary(item => item.Code);
    }
