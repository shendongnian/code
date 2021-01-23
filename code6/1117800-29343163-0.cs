    var onMondayAndTuesday = DailyTimeIntervalScheduleBuilder.Create()
                             .OnDaysOfTheWeek(new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday });
    var trigger = TriggerBuilder.Create()
                                .StartAt(DateBuilder.DateOf(StartHour, StartMinute, StartSeconds, StartDate, StartMonth, StartYear))
                                .WithSchedule(onMondayAndTuesday)
                                .WithCalendarIntervalSchedule(x => x.WithIntervalInWeeks(Int32.Parse(nWeekInterval)))
                                .EndAt(DateBuilder.DateOf(0, 0, 0, EndDay, EndMonth, EndYear))
                                .Build();
