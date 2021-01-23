    public static class GroupExtension
    {
        public static IEnumerable<IGrouping<int, T>> GroupAt<T>(this IEnumerable<T> source, int itemsPerGroup)
        {
            for(int i = 0; i < (int)Math.Ceiling( (double)source.Count() / itemsPerGroup ); i++)
            {
                var currentGroup = new Grouping<int,T>{ Key = i };
                currentGroup.AddRange(source.Skip(itemsPerGroup*i).Take(itemsPerGroup));
                yield return currentGroup;
            }
        }
        private class Grouping<TKey, TElement> : List<TElement>, IGrouping<TKey, TElement>
        {
            public TKey Key { get; set; }
        }
    }
