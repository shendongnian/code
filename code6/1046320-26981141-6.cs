	Dictionary<string, decimal> names = new Dictionary<string, decimal>();
	while (!sR.EndOfStream)
	{
		string line = sR.ReadLine();
		var entries = line.Split(new []{','}, StringSplitOptions.RemoveEmptyEntries);
		foreach(var entry in entries)
		{		
			decimal amount = decimal.Parse(entry.Split('$')[1]);
			string nameSplit = entry.Split('.', ':')[1].Trim();	
			
			if (names.ContainsKey(nameSplit))
			{
				names[nameSplit] += amount;
				Console.WriteLine("Hoozah!");
			}
			else
			{
				names.Add(nameSplit, amount);
				Console.WriteLine("Failure");
			}
		}
	}
