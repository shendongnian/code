    public class PropertyEqualityComparer<TItem> : EqualityComparer<TItem>
    {
    	readonly Func<TItem, object> _getter;
    	public PropertyEqualityComparer(Func<TItem, object> getter)
    	{
    		_getter = getter;
    	}
    	
    	public override bool Equals(TItem x, TItem y)
    	{
    		return _getter(x).Equals(_getter(y));
    	}
    	
    	public override int GetHashCode(TItem obj)
    	{
    		return _getter(obj).GetHashCode();
    	}
    }
    
    public static class ComparerLinqExtensions {
    	public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, object> keyGetter)
    	{
    		return first.Except(second, new PropertyEqualityComparer<TSource>(keyGetter));
    	}
    }
    // ...
    var itemsToRemove = oldList.Except(newList, foo => foo.Bar);
    var itemsToAdd = newList.Except(oldList, foo => foo.Bar);
