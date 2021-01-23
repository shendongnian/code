	string s = "201411241440";
	DateTime dt;
	if(DateTime.TryParseExact(s, "yyyyMMddHHmm",
                              CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		if(dt < DateTime.UtcNow.AddDays(-1))
        { 
            // do something.
        }
	}
