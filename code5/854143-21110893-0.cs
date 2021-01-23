    public static int DaysInWeek(DateTime arrivalDate, int weekNumber, int duration)
    {
        const int daysInAWeek = 7;
        //get the value of Saturday (your week start day)
        int firstDayOfWeekIndex = (int)DayOfWeek.Saturday;
        //get the day of week of the first day
        int startDay = arrivalDate.DayOfWeek;
    
        //Find out number of says until next Saturday (days in first week)
        int daysInFirstWeek = (startDay + firstDayOfWeekIndex) % daysInAWeek;
        //Get the 'Full Weeks', that have all 7 days in the duration
        int fullWeeks = (duration - daysInFirstWeek) / daysInAWeek;
        //Get any leftover days
        int leftover = duration - daysInAWeek * fullWeeks - daysInFirstWeek;
        //Get total number of weeks (complete or otherwise)
        int totalWeeks = 1 + fullWeeks + (leftover > 0 ? 1 : 0);
        //return accordingly
        if(weekNumber > totalWeeks)
           return 0;
        else if(weekNumber == 1)
           return daysInFirstWeek;
        else if(weekNumber == totalWeeks)
           return daysInLastWeek;
        else return daysInAWeek;
    }
