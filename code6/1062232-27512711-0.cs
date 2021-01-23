	string s = "\"2014-08-08 08:00:00\"";
	string format = "\\\"yyyy-MM-dd HH:mm:ss\\\"";
	DateTime date;
	if(DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out date))
	{
		Console.WriteLine (date);
	}
