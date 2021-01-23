     DateTime serverTime = DateTime.Now;
    
     DateTime utcTime = serverTime.ToUniversalTime(); 
    
    // convert it to Utc using timezone setting of server computer
    
     TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    
     DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi); 
    
    // convert from utc to local
