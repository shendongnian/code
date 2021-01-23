	string s = "\"2014-06-01T05:00:00.000Z\"";
	DateTime dt;
	if(DateTime.TryParseExact(s, "'\"'yyyy-MM-dd'T'HH:mm:ss.fff'Z\"'", 
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		dt.Dump();
	}
