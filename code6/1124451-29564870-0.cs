    public static class Extensions      {
    public static IEnumerable<IEnumerable<TSource>> BreakIntoChunks<TSource >(this IEnumerable<TSource> source, int size)
                {
                    TSource[] bucket = null;
                    var count = 0;
        
                    foreach (var item in source)
                    {
                        if (bucket == null)
                        {
                            bucket = new TSource[size];
                        }
        
                        bucket[count++] = item;
        
                        // The bucket is fully buffered before it's yielded
                        if (count != size)
                        {
                            continue;
                        }
        
                        // Select is necessary so bucket contents are streamed too
                        yield return bucket.Select(x => x);
        
                        bucket = null;
                        count = 0;
                    }
        
                    // Return the last bucket with all remaining elements
                    if (bucket != null && count > 0)
                    {
                        yield return bucket.Take(count);
                    }
                }
    }
