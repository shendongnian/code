    public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
    {
        using (IEnumerator<T> e = source.GetEnumerator())
        {
            if (source is IList<T>)
            {
                IList<T> list = (IList<T>)source;
                for (int i = count; i < list.Count; i++)
                {
                    e.MoveNext();
                    yield return list[i];
                }
            }
            else if (source is IList)
            {
                IList list = (IList)source;
                for (int i = count; i < list.Count; i++)
                {
                    e.MoveNext();
                    yield return (T)list[i];
                }
            }
            else
            {
                // .NET framework
                while (count > 0 && e.MoveNext()) count--;
                if (count <= 0)
                {
                    while (e.MoveNext()) yield return e.Current;
                }
            }
        }
    }
