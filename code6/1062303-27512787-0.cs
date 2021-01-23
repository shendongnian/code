    public static bool CompareDates(DateTime Date1, DateTime Date2)
    {
        int Datetime1Format = 0;
        int Datetime2Format = 0;
        var Date1Formats = Date1.GetDateTimeFormats();
        var Date2Formats = Date2.GetDateTimeFormats();
        for (int i = 0; i < Date1Formats.Length; i++)
        {
            if (Date1Formats[i] == Date1.ToString())
                Datetime1Format = i;
        }
        for (int k = 0; k < Date2Formats.Length; k++)
        {
            if (Date2Formats[k] == Date2.ToString())
                Datetime2Format = k;
        }
        if (Datetime1Format == Datetime2Format)
            return true;
        else
            return false;
 
    }
