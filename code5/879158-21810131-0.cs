	private List<int> filterNumbers(List<string> maybeNumbers)
	{
		List<int> onlyNumbers = new List<int>();
		foreach (var itemToCheck in maybeNumbers)
		{
			int number = 0;
			if (int.TryParse(itemToCheck, out number))
			{
				onlyNumbers.Add(number);
			}
		}
		return onlyNumbers;
	}
