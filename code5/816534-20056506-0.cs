    DateTime GetNextDate(DateTime from)
    {
        DayOfWeek target;
        switch (from.DayOfWeek)
        {
            case DayOfWeek.Friday:
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                target = DayOfWeek.Sunday;
                break;
            case DayOfWeek.Monday:
                target = DayOfWeek.Monday;
                break;
            case DayOfWeek.Tuesday:
            case DayOfWeek.Wednesday:
            case DayOfWeek.Thursday:
                target = DayOfWeek.Thursday;
                break;
            default:
                throw new ArgumentException("from");
        }
        while (from.DayOfWeek != target)
            from = from.AddDays(1);
        return from;
    }
