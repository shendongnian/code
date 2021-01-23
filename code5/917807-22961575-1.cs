	public static void HandleItemsAdded(IEnumerable<string> newItems)
	{
		foreach(var item in newItems)
			Console.WriteLine(item);
	}
