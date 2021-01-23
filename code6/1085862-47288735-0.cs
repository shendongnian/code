    public static DateTime numStrToDate(String val)
    {
        DateTime dRet = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        long dSec;
        if (long.TryParse(val, out dSec))
        {
            TimeSpan ts = new TimeSpan(dSec*10l);
            dRet = dRet.Add(ts);
        }
        return dRet;
    }
