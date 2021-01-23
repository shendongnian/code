	public void MoveToEnd<T>(LinkedList<T> list, int count)
	{
		if(list == null)
			throw new ArgumentNullException("list");
		if(count < 0 || count > list.Count)
			throw new ArgumentOutOfRangeException("count");
	
		for (int i = 0; i < count; ++i)
		{
			list.AddLast(list.First.Value);
			list.RemoveFirst();
		}
	}
	var snake = new[] { 0, 1, 2, 3, 4 };
	var list = new LinkedList<int>(snake);
	Console.WriteLine(string.Join(" ", list)); // 0 1 2 3 4
	MoveToEnd(list, 2);
	Console.WriteLine(string.Join(" ", list)); // 2 3 4 0 1
