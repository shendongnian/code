    public static class MyExtensions
    {
        public static IEnumerable<IEnumerable<TElement>> SplitBy<TElement>(
            this IEnumerable<TElement> source,
            TElement split,
            bool skipEmptyGroups = true)
            where TElement : IEquatable<TElement>
        {
            var group = new List<TElement>();
            foreach (var item in source)
            {
                if (split.Equals(item))
                {
                    if (group.Count > 0 || !skipEmptyGroups)
                    {
                        yield return group;
                        group = new List<TElement>();
                    }
                }
                else
                {
                    group.Add(item);
                }
            }
            if (group.Count > 0 || !skipEmptyGroups)
                yield return group;
        }
    }
