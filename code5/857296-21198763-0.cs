    var id = 3; //could be anything, this is just dummy;
    from tblWD in YourDbContext.WeekDays
    join tblDT in YourDbContext.DayTimes
    on tblWD.WeekDayId == tblDT.WeekDayId
    where tblWD.classID == id
    select new
    {
        WeekDay = tblWD.WeekDay,
        TimeFrom = tblDT.TimeFrom,
        TimeTo = tblDT.TimeTo
    };
