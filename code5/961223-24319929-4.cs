    DateTime today = DateTime.Today;
    DateTime start = new DateTime(today.Year,today.Month,today.Day,10,30,00);
    DateTime now = DateTime.Now;
    int hour = now.Hour;
    int mins = now.Minute;
    TimeSpan ts = now.Subtract(start);
    if(ts.TotalMinutes > 0) //Time now is after 10:30
     {  
      string lateBy = "You are late by:"+ ts.TotalMinutes.ToString();
     }
