    public static List<List<T> Batch(this IEnumerable<T> source, int batchSize)
    {
        List<List<T>> result = new List<List<T>>();
        List<T> batch = new List<T>(batchSize);
        foreach(T item in source)
        {
            if (batch.Count() == batchSize)
            {
                result.Add(batch);
                batch = new List<T>(batchSize);                 
            }
            batch.Add(item);
        }
        if (batch.Any())
           result.Add(batch);
        return result;
        
    }
