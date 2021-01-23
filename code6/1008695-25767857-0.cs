	public static IEnumerable<T> SelectNested<T>()
	{
		if (source != null){
			yield return source;
			var parent = selector(source);
			
            // Result of the recursive call is IEnumerable<T>
            // so you need to iterate over it and return its content.
			foreach (var parent in (SelectNested(selector(source))))
			{
				yield return parent;
			}
		}
	}
