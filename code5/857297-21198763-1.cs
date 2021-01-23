    //Change following variables accordingly
    var ctx = new YourDbContext();
    var id = 3;
    from tblWeekDays in ctx.WeekDays
    join tblDayTimes in ctx.DayTimes
    on tblWeekDays.WeekDayId == tblDayTimes.WeekDayId
    where tblWeekDays.classID == id
    select new
    {
        WeekDay = tblWeekDays.WeekDay,
        TimeFrom = tblDayTimes.TimeFrom,
        TimeTo = tblDayTimes.TimeTo
    };
