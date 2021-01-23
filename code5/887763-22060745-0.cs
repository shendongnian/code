        DateTime dt = new DateTime(2014,3,30,2,30,0);
        TimeZoneInfo tziSV = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
       		
        if (tziSV.IsInvalidTime(dt))
        {
           dt = dt.Add(tziSV.GetUtcOffset(dt));
        }
        DateTime dtSV = TimeZoneInfo.ConvertTimeToUtc(dt,tziSV);
