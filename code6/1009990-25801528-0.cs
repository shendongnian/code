	public static class GenericExtensions
	{
		public static bool EqualsAny<T>(this T value, params T[] comparables)
		{
			return comparables.Any(element => object.Equals(value, element));
		}
		public static bool EqualsNone<T>(this T value, params  T[] comparables)
		{
			return !EqualsAny(value, comparables);
		}
	}
