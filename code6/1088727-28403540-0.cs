        //Initial Delivery 5 Days
        DateTime start = DateTime.Now; //User Enters todayy as start
        DateTime end = start.AddDays(5); //User enters 5 days from now as end.
        //Get the ticks between now and 5 days time
        long ticksDiff = end.Ticks - start.Ticks;
        //Calculate 25% of difference
        long percentOfTicks = (long)(((double)ticksDiff) * 0.25);
        
        //This is your new date (orifiginal delivery date + 25%)
        DateTime newDelayedStart = end.AddTicks(percentOfTicks);
