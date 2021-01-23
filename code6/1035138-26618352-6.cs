    public static IEnumerable<IEnumerable<T>> ToConsecutiveGroups<T>(
        this IEnumerable<T> source, int size)
    {
        // You can check arguments here            
        Queue<T> bucket = new Queue<T>();
        foreach(var item in source)
        {
            bucket.Enqueue(item);
            if (bucket.Count == size)
            {
                yield return bucket.ToArray();
                bucket.Dequeue();
            }
        }
    }
