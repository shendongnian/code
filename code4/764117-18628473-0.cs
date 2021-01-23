	public static class ICollectionExtensions
	{
		public static bool IsEmpty<T>(this ICollection<T> collection)
		{
			return collection == null || collection.Count == 0;
		}
	}
	public static class IReadOnlyCollectionExtensions
	{
		public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection)
		{
			return collection == null || collection.Count == 0;
		}
	}
