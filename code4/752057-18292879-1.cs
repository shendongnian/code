        TimeZoneInfo timeZoneInfo; 
        DateTime dateTime ; 
    
        //Set the time zone information to Pacific Standard Time
        timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"); 
        //Get date and time in US Mountain Standard Time 
        dateTime = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
        //Print out the date and time
        Console.WriteLine(dateTime.ToString("yyyy-MM-dd HH-mm-ss")); 
