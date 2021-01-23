    public static class LinqEx
    {
        public static IEnumerable<List<TSource>> Split<TSource>(this IEnumerable<TSource> enu, TSource delimiter, IEqualityComparer<TSource> comparer = null)
        {
            // list == null handles the case where enu is empty
            List<TSource> list = null;
            if (comparer == null)
            {
                // Note how the equality comparer is "selected".
                // This is how LINQ methods do it
                // (see Enumerable.SequenceEqual<TSource>)
                comparer = EqualityComparer<TSource>.Default;
            }
            foreach (TSource el in enu)
            {
                if (comparer.Equals(el, delimiter))
                {
                    if (list == null)
                    {
                        list = new List<TSource>();
                    }
                    yield return list;
                    // Note that we have to recreate the list every time! 
                    // We can't simply do a list.Clear()
                    list = new List<TSource>();
                    continue;
                }
                if (list == null)
                {
                    list = new List<TSource>();
                }
                list.Add(el);
            }
            if (list != null)
            {
                yield return list;
            }
        }
        public static IEnumerable<List<TSource>> SplitRemoveEmpty<TSource>(this IEnumerable<TSource> enu, TSource delimiter, IEqualityComparer<TSource> comparer = null)
        {
            var list = new List<TSource>();
            if (comparer == null)
            {
                // Note how the equality comparer is "selected".
                // This is how LINQ methods do it
                // (see Enumerable.SequenceEqual<TSource>)
                comparer = EqualityComparer<TSource>.Default;
            }
            foreach (TSource el in enu)
            {
                if (comparer.Equals(el, delimiter))
                {
                    if (list.Count != 0)
                    {
                        yield return list;
                        // Note that we have to recreate the list every time! 
                        // We can't simply do a list.Clear()
                        list = new List<TSource>();
                    }
                    continue;
                }
                list.Add(el);
            }
            if (list.Count != 0)
            {
                yield return list;
            }
        }
    }
