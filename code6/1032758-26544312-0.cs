	string s = "Wed Oct 01 2014 00:00:00 GMT+0200";
	DateTime dt;
	if(DateTime.TryParseExact(s, "ddd MMM dd yyyy HH:mm:ss 'GMT'K", 
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		Console.WriteLine(dt);
	}
