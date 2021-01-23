	public static IEnumerable<TV> FlattenTreeProperty<T, TV>(this IEnumerable<T> collectionToRecurse, Func<T, IEnumerable<T>> childrenSelector, Func<T, TV> propertySelector)
	{
		var itemsToRecurse = (collectionToRecurse != null ? collectionToRecurse as IList<T> ?? collectionToRecurse.ToList() : new List<T>());
		if (!itemsToRecurse.Any())
		{
			yield break;
		}
		foreach (var item in itemsToRecurse.Select(propertySelector).Where(i => i != null))
		{
			yield return item;
		}
		foreach (var itemList in itemsToRecurse.Select(childrenSelector).Where(i => i != null))
		{
			foreach (var item in itemList.FlattenTreeProperty(childrenSelector, propertySelector))
			{
				yield return item;
			}
		}
	}
