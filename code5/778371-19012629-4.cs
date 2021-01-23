    public class PropertyEqualityComparer<TItem, TKey> : EqualityComparer<TItem>
    {
    	readonly Func<TItem, TKey> _getter;
    	public PropertyEqualityComparer(Func<TItem, TKey> getter)
    	{
    		_getter = getter;
    	}
    	
    	public override bool Equals(TItem x, TItem y)
    	{
            var xKey = _getter(x);
            var yKey = _getter(y);
            if (xKey == null && yKey == null) return true;
            if (xKey == null || yKey == null) return false;
    		return xKey.Equals(yKey);
    	}
    	
    	public override int GetHashCode(TItem obj)
    	{
            var key = _getter(obj);
            if (key == null) return 0;
    		return key.GetHashCode();
    	}
    }
    
    public static class ComparerLinqExtensions {
    	public static IEnumerable<TSource> Except<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keyGetter)
    	{
            var firstTuples = first.Select(it=>Tuple.Create(keyGetter(it), it));
            var secondTuples = second.Select(it=>Tuple.Create(keyGetter(it), it));
    		return firstTuples.Except(secondTuples, new PropertyEqualityComparer<Tuple<TKey, TSource>, TKey>(tuple=>tuple.Item1))
                                 .Select(tuple=>tuple.Item2);
    	}
    }
    // ...
    var itemsToRemove = oldList.Except(newList, foo => foo.Bar);
    var itemsToAdd = newList.Except(oldList, foo => foo.Bar);
