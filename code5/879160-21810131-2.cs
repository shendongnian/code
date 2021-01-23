	private List<string> filterNumbers(List<string> mix)
	{
		List<string> onlyStrings = new List<string>();
		foreach (var itemToCheck in mix)
		{
			int number = 0;
			if (!int.TryParse(itemToCheck, out number))
			{
				onlyStrings.Add(itemToCheck);
			}
		}
		return onlyStrings;
	}
