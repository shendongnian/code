	List<int> l = new List<int> { 3, 3, 1, 2, 3, 2 };
	int[] index = {0};
	var s = l.Select((k, i) =>
	{
		if (i < index[0])
			return null;
		int total = 0;
		return l.Skip(index[0]).TakeWhile(x =>
		{
			total += x;
			if (total <= 5)
				index[0]++;
			return total <= 5;
		});
	}).Where(x => x != null);
	foreach (IEnumerable<int> e in s)
	{
		foreach (int i in e)
		{
			Console.Write("{0},", i);
		}
		Console.WriteLine();
	}
