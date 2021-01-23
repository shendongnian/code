    public static DateTime GetEndOfMonth(DateTime start, bool workingDaysOnly)
    { 
        int year = start.Year;
        int month = start.Month;
        int daysInMonth = CultureInfo.CurrentCulture.DateTimeFormat.Calendar.GetDaysInMonth(year, month);
        var dt = new DateTime(year, month, daysInMonth);
        if (workingDaysOnly)
        {
            switch (dt.DayOfWeek)
            { 
                case DayOfWeek.Saturday:
                    dt = dt.AddDays(-1);
                    break;
                case DayOfWeek.Sunday:
                    dt = dt.AddDays(-2);
                    break;
                default:
                    break;
            }
        }
        return dt;
    }
