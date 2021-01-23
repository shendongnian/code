	string s = "141104";
	DateTime EntranceDeclaratioDate;
	if(DateTime.TryParseExact(s, "yyMMdd", CultureInfo.InvariantCulture,
							  DateTimeStyles.None,
                              out EntranceDeclaratioDate))
	{
		// Successfull parsing, now EntranceDeclaratioDate is 04/11/2014 00:00:00
	}
