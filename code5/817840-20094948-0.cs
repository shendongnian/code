    //Calculate Ticks in one year
    var now = DateTime.Now;
    var ticksInYear = (now.AddYears(1) - now).Ticks;
    
    //Create some dates
    DateTime first = DateTime.Today.AddYears(-1);
    DateTime second = Datetime.Today;
    
    //Get the difference
    long value = (second.Ticks - first.Ticks)/ticksInYear;
