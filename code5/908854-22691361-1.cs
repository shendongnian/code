	private static readonly DateTimeOffset _1970 = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
	public string UnixTimeToDateTime(int unixInput, string outputFormat, string timeZoneStandardName)
	{
		var objTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneStandardName);
		var utcDate = _1970.AddSeconds(unixInput);
		DateTimeOffset localDate = TimeZoneInfo.ConvertTime(utcDate, objTimeZoneInfo);
		return localDate.ToString(outputFormat);
	}
    //1970-01-01T13:00:00+13:00
    Console.WriteLine( UnixTimeToDateTime(0, "yyyy-MM-dd'T'HH:mm:sszzz", "New Zealand Standard Time"));
	
	//1970-01-01T08:00:00+08:00
    Console.WriteLine(UnixTimeToDateTime(0, "yyyy-MM-dd'T'HH:mm:sszzz", "Singapore Standard Time"));
	
	//1969-12-31T19:00:00-05:00
    Console.WriteLine(UnixTimeToDateTime(0, "yyyy-MM-dd'T'HH:mm:sszzz", "Eastern Standard Time"));
