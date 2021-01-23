    string orderDate = @"1/1/2014";
    string deliveryDate = @"6/2/2014";
    // This will give you a total number of days that passed between the two dates.
    double daysPassed = Convert.ToDateTime(deliveryDate).
                        Subtract(Convert.ToDateTime(orderDate)).TotalDays;
    // Use this if you want actual weeks.  This will give you a double approximate.  Change to it to an integer round it off (truncate it).
    double weeksPassed = daysPassed / 7;
    // Use this if you want to get an approximate number of work days in those weeks (based on 5 days a week schedule).
    double workDaysPassed = weeksPassed * 5;
    
