    public DateTime? GetNextScheduledDate(DateTime from)
    {
        var nextMonthDay = AllSchedules
            .Where(s => s.ScheduleType == Schedule.Type.Monthly && s.MonthDay >= from.Day)
            .OrderBy(s => s.MonthDay)
            .DefaultIfEmpty(AllSchedules
                .Where(s => s.ScheduleType == Schedule.Type.Monthly && s.MonthDay < from.Day)
                .OrderByDescending(s => s.MonthDay)
                .FirstOrDefault())
            .FirstOrDefault();
        var nextWeekDay = AllSchedules
            .Where(s => s.ScheduleType == Schedule.Type.Weekly)
            .Select(s => new { Schedule = s, Diff = ((int)s.WeekDay- (int)from.DayOfWeek) })
            .OrderBy(x => x.Diff >= 0)
            .ThenBy(x => Math.Abs(x.Diff))
            .FirstOrDefault();
        DateTime? nextMonthDate = null;
        DateTime? nextWeekDate = null;
        if (nextMonthDay != null)
        {
            int diff = nextMonthDay.MonthDay - from.Day;
            if (diff < 0)
            {
                // next month
                nextMonthDate = from.AddMonths(1).AddDays(diff);
            }
            else
            { 
                // this month
                nextMonthDate = from.AddDays(diff);
            }
        }
        if (nextWeekDay != null)
        {
            nextWeekDate = from.AddDays(nextWeekDay.Diff < 0 ? 7 - Math.Abs(nextWeekDay.Diff) : nextWeekDay.Diff);
        }
        if (!nextMonthDate.HasValue && !nextWeekDate.HasValue)
            return null;
        else
            return nextMonthDate < nextWeekDate ? nextMonthDate : nextWeekDate;
    }
