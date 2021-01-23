	public bool DoAnyValuesFail(
		Dictionary<string, int> dictionary,
		Func<int, bool> predicate)
	{
		return dictionary.Any(kvp => predicate(kvp.Value));
	}
