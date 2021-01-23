    public static class AsynchronousEnumerable
    {
        public static async Task<TSource> AggregateAsync<TSource>
                                          (this IEnumerable<TSource> source,
                                           Func<TSource, TSource, Task<TSource>> func)
        {
           using (IEnumerator<TSource> e = source.GetEnumerator())
		   {
                if (!e.MoveNext())
				{
					throw new InvalidOperationException("Sequence contains no elements");
				}
				
                TSource result = e.Current;
                while (e.MoveNext()) result = await func(result, e.Current);
                return result;
            }
        }
    }
