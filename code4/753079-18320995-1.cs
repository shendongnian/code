    TimeSpan timeSpan = endDate - startDate;
    var randomTest = new Random();
    for(var i = 0; i < 10; i++)
    {
        TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;
        // Do something with newDate before you loop again
    }
