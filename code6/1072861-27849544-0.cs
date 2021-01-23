    public static IEnumerable<Tuple<T, int>> Rank<T>(this IEnumerable<T> source)
    {
        var query = source.GroupBy(x => x)
            .OrderByDescending(x => x.Key);
        var rank = 1;
        foreach (var group in query)
        {
            var groupRank = rank;
            foreach (var item in group)
            {
                yield return Tuple.Create(item, groupRank);
                rank++;
            }
        }
    }
