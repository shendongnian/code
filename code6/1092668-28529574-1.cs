	public static class EnumerableReflect
	{
		private static string OneElementReflect<T>(T e, PropertyInfo[] props)
		{
			var values = props.Select(x => x.GetValue(e).ToString());
			return "{" + string.Join(", ", values)) + "}";
		}
		public static IEnumerable<string> enumerbleString<T>(this IEnumerable<T> collection, params string[] PropertysNames)
		{
			var props = PropertysNames.Select(x => typeof(T).GetProperty(x)).ToArray();
			return collection.Select(x => OneElementReflect(x, props));
		}
	}
