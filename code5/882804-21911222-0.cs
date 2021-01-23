    @{
        DateTime start = new DateTime(2013, 08, 12);
        DateTime end = new DateTime(2013, 08, 24);
    
    
        for (DateTime d = start; d < end; d = d.AddDays(1))
        {
            @(d.ToString()) <br/>
        }
    }
