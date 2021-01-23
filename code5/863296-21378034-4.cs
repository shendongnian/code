    public static IEnumerable<T> GetRange<T>(
        this IEnumerable<T> source, Func<T, bool> predicate, int range)
    {
        int itemsToFetch = range * 2 + 1;
        Queue<T> queue = new Queue<T>(range + 1);
        bool itemFound = false;
        int itemsFetched = 0;
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (itemFound) // if item found, then just yielding all next items
                {
                    yield return current; // we don't need queue anymore
                    itemsFetched++;
                }
                else
                {
                    if (predicate(current))
                    {
                        itemFound = true;
                        while (queue.Any()) // yield all content of queue
                            yield return queue.Dequeue();
                        yield return current; // and item which matched predicate
                        itemsToFetch = range;
                    }
                    else
                    {
                        queue.Enqueue(current);
                        if (queue.Count >= range)
                            queue.Dequeue();
                    }
                }
                if (itemsFetched == itemsToFetch)
                    break;
            }
        }
    }
