	public static class IEnumerableExtensions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable == null || enumerable.Count() == 0;
		}
	}
