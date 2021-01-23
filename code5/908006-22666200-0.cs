	public static string NormalisePath(string path)
	{
		var components = path.Split(new Char[] {'/'});
		
		var retval = new Stack<string>();
		foreach (var bit in components)
		{
			if (bit == "..")
			{
				if (retval.Any())
				{
					var popped = retval.Pop();
					if (popped == "..")
					{
						retval.Push(popped);
						retval.Push(bit);
					}
				}
				else
				{
					retval.Push(bit);
				}
			}
			else
			{
				retval.Push(bit);
			}
		}
		
		var final = retval.ToList();
		final.Reverse();
		return string.Join("/", final.ToArray());
	}
