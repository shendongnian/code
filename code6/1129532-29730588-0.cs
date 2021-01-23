	string text = "This  is a random string that I'll iterate through " +
				  "to find out how many instances of a character it contains";
		
	Dictionary<char, int> Counter = new Dictionary<char, int>();
	foreach (char c in text)
	{
		if (!Counter.ContainsKey(c))
		{
			Counter.Add(c, 0);
		}
		
		Counter[c] += 1;
	}
	foreach (var kv in Counter)
	{
		Console.WriteLine ("The character {0} occured {1} times", kv.Key, kv.Value);
	}
