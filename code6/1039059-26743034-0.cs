    static Dictionary<string, MyItem> GetLatestCodes(
        IEnumerable<MyItem> items, DateTime latestAllowableTimestamp)
    {
        return items
            .GroupBy(item => item.Code)
            .Select(group => group
                .OrderByDescending(item => item.TimeStamp)
                .FirstOrDefault(item => item.TimeStamp <= latestAllowableTimestamp)
                )
            .Where(item => item != null)
            .ToDictionary(item => item.Code);
    }
