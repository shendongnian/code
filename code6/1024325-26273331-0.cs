    if (today == DayOfWeek.Thursday && thursdaytime == "Closed") 
    {
        sqlreadclosed(); 
        //goto Ended;
    }
    else if (
        today == DayOfWeek.Thursday 
        && (
            DateTime.Now.TimeOfDay > System.TimeSpan.Parse(thursdaytime.Substring(6, 5)) 
            || DateTime.Now.TimeOfDay < System.TimeSpan.Parse(thursdaytime.Substring(0, 5))
        )
    )
    {
        sqlreadclosed();              
    }
    else
    {
        sqlreadopen();                 
    }
    //Ended:
