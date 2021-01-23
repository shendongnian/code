	if (((Func<bool>)(() =>
	{
		// Multi-statement evaluation
		DateTime dt = DateTime.UtcNow;
		if (dt.Hour <= 12)
			return true;
		else
			return false;
	}))())
	{
		Console.WriteLine("Early");
	}
	else
	{
		Console.WriteLine("Late");
	}
