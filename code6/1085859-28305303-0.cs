     private static DateTime UnixTimeStampToDateTime(long unixTimeStamp) 
     {
        System.DateTime dtDateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp);
        return dtDateTime;
     }
