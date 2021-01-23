	public IEnumerable<string> GetAllInstrings(string text)
	{
		yield return text.Substring(0, 1);
		if (text.Length > 1)
		{
			foreach (var element in GetAllInstrings(text.Substring(1)))
			{
				yield return element;
				yield return text.Substring(0, 1) + element;
			}
		}
	}
