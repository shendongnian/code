    public static IEnumerable<T> GetRange<T>(
        this IEnumerable<T> source, Func<T, bool> predicate, int range)
    {            
        Queue<T> queue = new Queue<T>(range);
        bool itemFound = false;
        int itemsToReturnAfterMatch = range + 1;
        using (var iterator = source.GetEnumerator())
        {
            while (iterator.MoveNext())
            {
                T current = iterator.Current;
                if (!itemFound)
                {
                    if (predicate(current))
                    {
                        itemFound = true;
                        while (queue.Any())
                            yield return queue.Dequeue();
                    }
                    else
                    {
                        if (queue.Count == range)
                            queue.Dequeue();
                        queue.Enqueue(current);
                    }
                }
                    
                if (itemFound)
                {                        
                    yield return current;
                    itemsToReturnAfterMatch--;
                }
                if (itemsToReturnAfterMatch == 0)
                    break;                
            }
        }
    }
