       int count = Start < EndDate ? 1 : -1;
       DateTime newDate = StartDate;
       List<DateTime> allDaysList = new List<DateTime();
       while(newDate != EndDate)
       {
           newDate = newDate.AddDays(count); //will eithr add or subtract a day
           allDays.Add(newDate);           
       }
       //now return either only weekdays days
       allDays = allDays.Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);
