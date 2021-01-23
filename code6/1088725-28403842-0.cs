        //Set dates
        DateTime? beginDate = DateTime.Now;
        DateTime? endDate = DateTime.Now.AddDays(10);
        //Check both values have a value (they will based on above)
        //If they do get the ticks between them
        long diff = 0;
        if (beginDate.HasValue && endDate.HasValue)
            diff = endDate.Value.Ticks - beginDate.Value.Ticks;
        
        //Get difference in ticks as a time span to get days between.
        int daysDifference =  new TimeSpan(diff).Days;
