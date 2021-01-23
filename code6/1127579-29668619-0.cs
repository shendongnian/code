	string s = "December 6, 2011";
	DateTime dt;
	if(DateTime.TryParseExact(s, "MMMM d, yyyy", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt); // 06/12/2011 00:00:00
	}
