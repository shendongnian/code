    public static void ProcessInBatches<TSource>(
                  this IEnumerable<TSource> source,
                  int batchSize,
                  Action<IEnumerable<TSource>> action)
    {
        foreach (var batch in source.Batch(batchSize))
        {
            action(batch);
        }
    }
