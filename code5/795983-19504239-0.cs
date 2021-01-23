	string wichOp = "r";
	while (wichOp == "r")
	{
		Console.WriteLine("Kaj je toni?");
		Console.WriteLine("Izber med:   -A   -B   -C   -D   -E");
		wichOp = Console.ReadLine();
		wichOp = wichOp.ToLower();
		if (wichOp == "a")
		{
			Console.Write("Toni je BK");
		}
		else if (wichOp == "b")
		{
			Console.Write("Toni je PEDER");
		}
		else if (wichOp == "c")
		{
			Console.Write("Toniju Baloni");
		}
		else if (wichOp == "d")
		{
			Console.Write("Toni je buzi");
		}
		else if (wichOp == "e")
		{
			Console.Write("TONI ŠAMPION");
		}
		else if (wichOp != "r")
			Console.WriteLine("Nisi vnesil pravilno izbiro");
	}
