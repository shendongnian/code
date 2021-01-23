    // Sets the Month Calenders Min & Max to days in current month.
             DateTime dt = DateTime.Today;
             DateTime firstDay = new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
             DateTime lastDay = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
    
             dateMonthCalender.MinDate = firstDay;
             dateMonthCalender.MaxDate = lastDay;
