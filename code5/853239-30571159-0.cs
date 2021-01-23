        public static IEnumerable<T[]> PartitionBySize<T>(this IEnumerable<T> source, int[] sizes)
        {
            using (var iter = source.GetEnumerator())
                foreach (var size in sizes)
                    if (iter.MoveNext())
                    {
                        var chunk = new T[size];
                        chunk[0] = iter.Current;
                        int i = 1;
                        for (; i < size && iter.MoveNext(); i++)
                            chunk[i] = iter.Current;
                        if (i < size)
                            Array.Resize(ref chunk, i);
                        yield return chunk;
                    }
                    else
                        yield break;
        }
        public static IEnumerable<T[]> PartitionByIdx<T>(this IEnumerable<T> source, int[] indexes)
        {
            int last = -1;
            using (var iter = source.GetEnumerator())
                foreach (var idx in indexes)
                {
                    int size = idx - last;
                    last = idx;
                    if (iter.MoveNext())
                    {
                        var chunk = new T[size];
                        chunk[0] = iter.Current;
                        int i = 1;
                        for (; i < size && iter.MoveNext(); i++)
                            chunk[i] = iter.Current;
                        if (i < size)
                            Array.Resize(ref chunk, i);
                        yield return chunk;
                    }
                    else
                        yield break;
                }
        }
