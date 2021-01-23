         if (today == DayOfWeek.Thursday && thursdaytime == "Closed") 
              {
              sqlreadclosed(); 
              skipflag = false;
              }
         else{
              skipflag = true;
         }
     if(skipflag)
    {
         if (today == DayOfWeek.Thursday && DateTime.Now.TimeOfDay > System.TimeSpan.Parse(thursdaytime.Substring(6, 5)) || DateTime.Now.TimeOfDay < System.TimeSpan.Parse(thursdaytime.Substring(0, 5)))
              {
              sqlreadclosed();              
              }
              Else
              {
              sqlreadopen();                 
              }
    }
