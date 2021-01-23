    public class MemoizedEnumerable<T> : IEnumerable<T>, IDisposable
    {
       private readonly IEnumerator<T> _childEnumerator;
       private readonly List<T> _itemCache = new List<T>();
    
       public MemoizedEnumerable(IEnumerable<T> enumerableToMemoize)
       {
           _childEnumerator = enumerableToMemoize.GetEnumerator();
       }
    
       public IEnumerator<T> GetEnumerator()
       {
           return _itemCache.Concat(EnumerateOnce()).GetEnumerator();
       }
    
       public void Dispose()
       {
           _childEnumerator.Dispose();
       }
       private IEnumerable<T> EnumerateOnce()
       {
           while (_childEnumerator.MoveNext())
           {
               _itemCache.Add(_childEnumerator.Current);
               yield return _childEnumerator.Current;
           }
       }
           
       IEnumerator IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Memoize<T>(this IEnumerable<T> enumerable)
        {
            return new MemoizedEnumerable<T>(enumerable);
        }
    }
