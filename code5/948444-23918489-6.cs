	// My Extension Methods
	public static class MyExt
	{
	
		public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> list)
		{
			if (list.Count() == 1)
				return new List<IEnumerable<T>> { list };
			return list
				.Select((a, i1) => 
							Permute(list.Where((b, i2) => i2 != i1))
						.Select(b => (new List<T> { a }).Union(b)))
				.SelectMany(c => c);
		}
	
	
		public static string ToString2<T>(this List<T> list)
		{
			StringBuilder results = new StringBuilder("{ ");
			var size = list.Count();
			var pos = 1;
			
			foreach( var i in list )
			{
				results.Append(i.ToString());
				if(pos++!=size)
					results.Append(", ");
			}
			
			results.Append(" }");				
			return results.ToString().Trim(',');
		}
	}
