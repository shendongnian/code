	string s = "1/22/2004";
	DateTime dt;
	if(DateTime.TryParseExact(s, "M/dd/yyyy", CultureInfo.GetCultureInfo("en-US"),
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt); // 22 January 2004 00:00:00
	}
