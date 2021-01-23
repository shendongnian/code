	public IEnumerable<string> GetExistingNames(ICollection<string> names)
	{
		List<Names> data = context.Where(n => names.Contains(n)).ToList();
		if(data == null) yield break;
		foreach(var name in data)
		{
			yield return name.Name;
		}
	}
