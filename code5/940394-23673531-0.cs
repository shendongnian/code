    public void SaveFrameGpsCoordinate()
    {
        int listSize = gpsDataList.Count - 1;
    
        DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
        dateTimeFormatInfo.ShortDatePattern = "dd-MM-yyyy HH:mm:ss";
        dateTimeFormatInfo.DateSeparator = "/";
    
        //DateTime tempDateA = DateTime.ParseExact(gpsDataList[0].timeCaptured, "dd/MM/yyyy HH:mm:ss",null);
        //DateTime tempDateB = DateTime.ParseExact(gpsDataList[lastRecordData].timeCaptured, "dd/MM/yyyy HH:mm:ss", null);
    
        DateTime tempDateA = Convert.ToDateTime(gpsDataList[0].timeCaptured.Replace("\"", ""), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        DateTime tempDateB = Convert.ToDateTime(gpsDataList[lastRecordData].timeCaptured.Replace("\"", ""), System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
    }
