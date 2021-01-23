	public class PropertyEqualityComparer<TItem> : EqualityComparer<TItem>
	{
		readonly Func<TItem, object> _getter;
		public PropertyEqualityComparer(Func<TItem, object> getter)
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
    	public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, object> keyGetter)
    	{
    		return first.Except(second, new PropertyEqualityComparer<TSource>(keyGetter));
    	}
    }
    // ...
    var itemsToRemove = oldList.Except(newList, foo => foo.Bar);
    var itemsToAdd = newList.Except(oldList, foo => foo.Bar);
