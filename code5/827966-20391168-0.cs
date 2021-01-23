    static DateTime date;
    public static void setDay(String day)
    {
        DayOfWeek futureDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day);
        int futureDayValue = (int)futureDay;
        int currentDayValue = (int)DateTime.Now.DayOfWeek;
        int dayDiff = futureDayValue - currentDayValue;
        if (dayDiff > 0)
        {
            date = DateTime.Now.AddDays(dayDiff);
        }
        else
        {
            date = DateTime.Now.AddDays(dayDiff + 7);
        }
    
    
    }
