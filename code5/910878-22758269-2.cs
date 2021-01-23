	string sDate = ds.Tables[0].Rows[i][0].ToString();
	string sTime = ds.Tables[0].Rows[i][1].ToString();	
	DateTime dDateTime;		
	DataRow dr = dt.NewRow();
	//cond: for checking the datetime parsing
	if (DateTime.TryParseExact(sDate, "M/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dDateTime))
	{	
		//sDate  = dDateTime.ToString("M/dd/yyyy");
		//dr["StartDate"] = sDate;	
                dr["StartDate"] = dDateTime;
	}	
	//cond: for checking the datetime parsing
	if (DateTime.TryParseExact(sTime, "hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dDateTime))
	{	
		//sTime  = dDateTime.ToString("h:mm:ss");
		//dr["StartTime"] = sTime;
                  dr["StartTime"] = dDateTime;	
	}
