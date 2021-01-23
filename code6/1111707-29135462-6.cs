    public static DaylightTime GetDaylightChanges(string timeZoneName, int year)
    {
        TimeZoneInfo currentTimezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
        var currentRules =
            currentTimezone.GetAdjustmentRules().FirstOrDefault(rule =>
                rule.DateStart <= DateTime.Today &&
                rule.DateEnd >= DateTime.Today);
        if (currentRules != null)
        {
            var daylightStart = 
                GetTransitionDate(currentRules.DaylightTransitionStart, year);
            var daylightEnd = 
                GetTransitionDate(currentRules.DaylightTransitionEnd, year);
            return new DaylightTime(daylightStart, daylightEnd, 
                currentRules.DaylightDelta);
        }
            
        return null;
    }
    private static DateTime GetTransitionDate(TimeZoneInfo.TransitionTime transition, 
        int year)
    {
        return (transition.IsFixedDateRule)
            ? new DateTime(year, transition.Month, transition.Day,
                transition.TimeOfDay.Hour, transition.TimeOfDay.Minute,
                transition.TimeOfDay.Second)
            : GetNonFixedTransitionDate(transition, year);
    }
    private static DateTime GetNonFixedTransitionDate(
        TimeZoneInfo.TransitionTime transition, int year)
    {
        var calendar = CultureInfo.CurrentCulture.Calendar;
        int startOfWeek = transition.Week * 7 - 6;
        int firstDayOfWeek = (int) calendar.GetDayOfWeek(new DateTime(year, 
            transition.Month, 1));
        int changeDayOfWeek = (int) transition.DayOfWeek;
        int transitionDay = (firstDayOfWeek <= changeDayOfWeek) 
            ? startOfWeek + (changeDayOfWeek - firstDayOfWeek)
            : startOfWeek + (7 - firstDayOfWeek + changeDayOfWeek);
        if (transitionDay > calendar.GetDaysInMonth(year, transition.Month))
            transitionDay -= 7;
        return new DateTime(year, transition.Month, transitionDay, 
            transition.TimeOfDay.Hour, transition.TimeOfDay.Minute, 
            transition.TimeOfDay.Second);
    }   
