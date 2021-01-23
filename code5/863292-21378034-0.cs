    public static IEnumerable<T> GetRange<T>(
        this IEnumerable<T> source, Func<T, bool> predicate, int range)
    {            
        Queue<T> queue = new Queue<T>(range + 1);
        bool itemFound = false;
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                queue.Enqueue(current);                    
                if (!itemFound && predicate(current))
                {
                    itemFound = true;                        
                    while(queue.Any())
                        yield return queue.Dequeue();
                }
                if (!itemFound && queue.Count > range)
                    queue.Dequeue();
                if (itemFound && queue.Count == range)
                    break;
            }
        }
        while (queue.Any())
            yield return queue.Dequeue();
    }
