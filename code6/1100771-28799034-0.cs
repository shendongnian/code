    DateTime dateTimeIhave = TimeZoneInfo.ConvertTime(dateTheyGave, theirTimeZone, yourTimeZone);
    if (dateTimeIhave > DateTime.Now.AddMinutes(1)
                && dateTimeIhave < DateTime.Now.AddMinutes(10))
    {
        doSomething();
    } 
