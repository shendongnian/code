	public static class EnumerableExtensions {
		public static IEnumerable<T> GetValues<T>(this IEnumerable<T> enumerable, params Int32[] indices) {
			return indices.Select(enumerable.ElementAt);
		}
	}
