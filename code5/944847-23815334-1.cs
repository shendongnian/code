	string s =  "05/22/2014";
	DateTime dt;
	if(DateTime.TryParseExact(s, "MM/dd/yyyy", CultureInfo.CurrentCulture,
							  DateTimeStyles.None, out dt))
	{
	   // parsing successful
	}
	else
	{
	   // not successful
	}
