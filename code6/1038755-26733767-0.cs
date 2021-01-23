	string s = "2014-09-25 09:18:24";
	DateTime dt;
	if(DateTime.TryParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
