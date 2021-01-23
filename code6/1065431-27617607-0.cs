    var groupedData = resultSet.AsQueryable()
                               .Select("CreatedDate")
                               .AsEnumerable<long>()
                               .GroupBy(UnixTimestampToDate)
                               .Select(g => new { g.Key, Count = g.Count() });
    ...
    private static readonly DateTime UnixEpoch =
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private static DateTime UnixTimestampToDate(long timestamp)
    {
        return UnixEpoch.AddSeconds(timestamp)
                        .Date;
    }
