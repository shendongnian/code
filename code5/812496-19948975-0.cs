    public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> list, int size)
    {
        List<T> batch = new List<T>(size);
        foreach(var item in list)
        {
           batch.Add(item);
           if (batch.Count >= size)
           {
             yield return batch;
             batch = new List<T>(size);
           }
        }
        
        if (batch.Count > 0)
          yield return batch;
    }
