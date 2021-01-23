    //Get the date of the previous Monday
    DateTime prevMonday = DateTime.Now;
    while(prevMonday.DayOfWeek != DayOfWeek.Monday)
          prevMonday = prevMonday.AddDays(-1);
    
 
    //get user's date 
    DateTime aa = Convert.ToDateTime(rr.detail);
    
    //check if the user's date is after the Monday
    if (aa > prevMonday && aa <= DateTime.Now.Date)    
        Console.WriteLine(aa.DayOfWeek);
    else
        Console.WriteLine(aa);
