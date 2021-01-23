    public class PropertyEqualityComparer<TItem, TKey> : EqualityComparer<Tuple<TItem, TKey>>
    {
    	readonly Func<TItem, TKey> _getter;
    	public PropertyEqualityComparer(Func<TItem, TKey> getter)
    	{
    		_getter = getter;
    	}
        
        public Tuple<TItem, TKey> Wrap(TItem item) {
            return Tuple.Create(item, _getter(item));
        }
        
        public TItem Unwrap(Tuple<TItem, TKey> tuple) {
            return tuple.Item1;
        }
    	
    	public override bool Equals(Tuple<TItem, TKey> x, Tuple<TItem, TKey> y)
    	{
            if (x.Item2 == null && y.Item2 == null) return true;
            if (x.Item2 == null || y.Item2 == null) return false;
    		return x.Item2.Equals(y.Item2);
    	}
    	
    	public override int GetHashCode(Tuple<TItem, TKey> obj)
    	{
            
            if (obj.Item2 == null) return 0;
    		return obj.Item2.GetHashCode();
    	}
    }
    
    public static class ComparerLinqExtensions {
    	public static IEnumerable<TSource> Except<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keyGetter)
    	{
            var comparer = new PropertyEqualityComparer<TSource, TKey>(keyGetter);
            var firstTuples = first.Select(comparer.Wrap);
            var secondTuples = second.Select(comparer.Wrap);
    		return firstTuples.Except(secondTuples, comparer)
                              .Select(comparer.Unwrap);
    	}
    }
    // ...
    var itemsToRemove = oldList.Except(newList, foo => foo.Bar);
    var itemsToAdd = newList.Except(oldList, foo => foo.Bar);
