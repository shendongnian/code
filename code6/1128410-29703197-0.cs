    // get start and end as DateTime
    
    int year;
    DateTime springStart, summerStart, autumnStart, winterStart;
        
    for (DateTime date = start; date < end; date = date.AddMonths(3))
    { 
        year = date.Year;
        springStart = new DateTime(year, 3, 21);
        //etc...
        if (date >= springStart && date < summerStart)
        { //etc...}
        else if (date >= winterStart || date < springStart)
        { //etc...}
    }
