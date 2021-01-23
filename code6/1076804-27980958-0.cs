	string s = "6/11/2014 9:00";
	DateTime dt;
	if(DateTime.TryParseExact(s, "d/MM/yyyy H:mm", CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));
        // result will be 2014-11-06 09:00:00
	}
