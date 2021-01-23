    var startDate= dtpStartDate.Date;
    var endDate= dtpEndDate.Date;
    List<DateTime> workingDays= new List<DateTime>();
    
    for(DateTime counter= startDate; counter<= endDate; counter=counter.AddDays(1))
    {
    if(counter.DayOfWeek !="Saturday" && counter.DayOfWeek!="Sunday")
       workingDays.Add(counter);
    }
    // Here you can use the list of working days.
