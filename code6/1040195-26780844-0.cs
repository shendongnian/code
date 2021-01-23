	string txtdate = "8/11/2014";
	DateTime dt;
	if(DateTime.TryParseExact(txtdate, "M/dd/yyyy",
	                          CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt))
	{
		
	}
	string txtdate1 = "9/11/2014";
	DateTime dt1;
	if(DateTime.TryParseExact(txtdate1, "M/dd/yyyy",
	                          CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out dt1))
	{
	}
    var totaldays = (dt1 - dt).TotalDays; // 31
