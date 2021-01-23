    TimeSpan tsFrom;
    TimeSpan tsTo;
    
    string sFrom = "00:10:38";
    string sTo = "00:00:04";
    
    if (TimeSpan.TryParse(sFrom, out tsFrom) && TimeSpan.TryParse(sTo, out tsTo))
    {
        TimeSpan ts = tsFrom + tsTo; // 00:10:42
    }
