	public IEnumerable<string> GetExistingNames(ICollection<string> names)
	{
		IQueryable<Names> query = Names.Where(n => names.Contains(n.Name));
		if (query == null) yield break;
		foreach (var name in query)
		{
			yield return name.Name;
		}
	}
