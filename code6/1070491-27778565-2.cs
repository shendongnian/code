    static class MyDistinctExtensions
    {
        public static IEnumerable<T> DistinctMaxElements<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer) where T : ICollection
        {
            Dictionary<T, List<T>> dictionary = new Dictionary<T, List<T>>(comparer);
            foreach (var item in source)
            {
                List<T> list;
                if (!dictionary.TryGetValue(item, out list))
                {
                    list = new List<T>();
                    dictionary.Add(item, list);
                }
                list.Add(item);
            }
            foreach (var list in dictionary.Values)
            {
                yield return list.Select(x => new { List = x, Count = x.Count })
                    .OrderByDescending(x => x.Count)
                    .First().List;
            }
        }
    }
