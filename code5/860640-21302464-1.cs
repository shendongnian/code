    public static IEnumerable<T> TakeIfMoreThan<T>(
        this IEnumerable<T> source, int count)
    {
        List<T> buffer = new List<T>(count);
        using (var iterator = source.GetEnumerator())
        {
             while (buffer.Count < count && iterator.MoveNext())
                    buffer.Add(iterator.Current);
             if (buffer.Count < count)
             {
                  yield break;
             }
             else
             {
                foreach (var item in buffer)
                    yield return item;
                buffer.Clear();
                while (iterator.MoveNext())
                    yield return iterator.Current;
            }            
        }
    }
