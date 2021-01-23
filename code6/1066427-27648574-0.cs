	static void Main(string[] args)
	{
		string[] unsorted = { "z", "e", "x", "c", "m", "q", "a" };
		// Print the unsorted array.
		for (int i = 0; i < unsorted.Length; i++)
			Console.Write(unsorted[i] + " ");
		Console.WriteLine();
		// Get a copy of the array, as a list.
		List<string> list = unsorted.ToList();
		// Sort the list.
		QuicksortParallel(list, 0, list.Count - 1);
		// Print the sorted list.
		for (int i = 0; i < list.Count; i++)
			Console.Write(list[i] + " ");
		Console.WriteLine();
		Console.ReadKey();
	}
