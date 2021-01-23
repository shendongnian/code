    var condensedLoginRecordLines = monTimes
       .Concat(tueTimes)
       .Concat(wedTimes)
       ..//etc
       .Select(data => new CondensedLine { WeekDay = data.WeekDay, /* here all the properties are initialized */ })
       .ToList();
