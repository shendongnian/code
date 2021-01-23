	private void FilterNumbers(List<string> numbers)
	{
		// create a copy of the list, 
		// so that removal does not affect the iteration
		foreach (var item in numbers.ToList())
		{
			if(item.All(Char.IsDigit))
			{
				numbers.Remove(item);
			}
		}
	}
