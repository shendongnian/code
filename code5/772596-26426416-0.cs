     //Using the ToList() method
    IEnumerable<CalendarDate> LessonDates = db.CalendarDates.ToList().Where(cd => cd.Date.DayOfWeek == DayOfWeek.Friday);
    
    //Using the AsEnumerable() method
    IEnumerable<CalendarDate> LessonDates = db.CalendarDates.AsEnumerable().Where(cd => cd.Date.DayOfWeek == DayOfWeek.Friday);
