	public static class EnumerableReflect
	{
		private static string OneElementReflect<T>(T e, PropertyInfo[] props)
		{
			var sb = new StringBuilder();
			sb.Append("{");
			var values = props.Select(x => x.GetValue(e).ToString());
			sb.Append(string.Join(", ", values));
			sb.Append("}");
			return sb.ToString();
		}
		public static IEnumerable<string> enumerbleString<T>(this IEnumerable<T> collection, params string[] PropertysNames)
		{
			var props = PropertysNames.Select(x => typeof(T).GetProperty(x)).ToArray();
			return collection.Select(x => OneElementReflect(x, props));
		}
	}
