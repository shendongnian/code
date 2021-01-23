    private DateTime GetDateTime(string tempDate)
    {
        DateTime actualdate;
        if (tempDate.Contains('.'))
        {
           DateTime.TryParseExact(tempdate.SubString(0,6), "yyyymm", out actualdate)
        }
        else 
        {
            DateTime.TryParseExact(tempdate, "yyyymmdd", out actualdate)
        }
    
        return actualdate;
    }
