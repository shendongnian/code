    public static IEnumerable<T> IntersectAll<T>(
       this IEnumerable<T> list, 
       params IEnumerable<T>[] otherLists
    ) {
		foreach (var otherList in otherLists)
		{
			list = list.Intersect(otherList);
		}
		return list;
	}
