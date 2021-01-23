    if (today == DayOfWeek.Thursday) {
       if(thursdaytime == "Closed" || (DateTime.Now.TimeOfDay > System.TimeSpan.Parse(thursdaytime.Substring(6, 5)) || DateTime.Now.TimeOfDay < System.TimeSpan.Parse(thursdaytime.Substring(0, 5)))){
         sqlreadclosed(); 
       else{
         sqlreadopen(); 
       }
    }
