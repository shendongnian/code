    void Main()
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        System.Globalization.DateTimeStyles style = DateTimeStyles.None;
        string[] format = new string[] { "d/MMM/yy h:m:s tt","d-MMM-yy h:m:s tt" }; 
        //                                         ^                   ^
        //                                         +------ here -------+
        string strDate = "24-May-13 12:03:03 AM";
        
        DateTime dt;
        if (DateTime.TryParseExact(strDate, format, provider, style, out dt))
        {
            dt.Dump();
            dt.Hour.Dump();
        }
    }
