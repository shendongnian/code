    // This is a static class because the Split(x) are extension
    // methods
    public static class LinqEx
    {
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> enu, T delimiter)
        {
            // list == null handles the case where enu is empty
            List<T> list = null;
            foreach (T el in enu)
            {
                if (el.Equals(delimiter))
                {
                    if (list == null)
                    {
                        list = new List<T>();
                    }
                    yield return list;
                    // Note that we have to recreate the list every time! 
                    // We can't simply do a list.Clear()
                    list = new List<T>();
                    continue;
                }
                if (list == null)
                {
                    list = new List<T>();
                }
                list.Add(el);
            }
            if (list != null)
            {
                yield return list;
            }
        }
        public static IEnumerable<List<T>> SplitRemoveEmpty<T>(this IEnumerable<T> enu, T delimiter)
        {
            var list = new List<T>();
            foreach (T el in enu)
            {
                if (el.Equals(delimiter))
                {
                    if (list.Count != 0)
                    {
                        yield return list;
                        // Note that we have to recreate the list every time! 
                        // We can't simply do a list.Clear()
                        list = new List<T>();
                        continue;
                    }
                }
                list.Add(el);
            }
            if (list.Count != 0)
            {
                yield return list;
            }
        }
    }
