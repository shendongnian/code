    //Dates for testing
    List<DateTime> dates = new List<DateTime>()
    { 
        new DateTime(2014,1,1),
        new DateTime(2014,1,2),
        new DateTime(2014,2,1),
        new DateTime(2014,2,2),
        new DateTime(2014,2,16),
        new DateTime(2014,3,13),
    };
    
    //the month that define the groups
    var months = dates.Select(d => d.Month).Distinct().ToList();
    
    //create the groups
    List<List<DateTime>> groups = new List<List<DateTime>>();
    months.ForEach(m => 
        {
            var currGroup = dates.Where(d => d.Month == m).ToList();
            groups.Add(currGroup);
        });
