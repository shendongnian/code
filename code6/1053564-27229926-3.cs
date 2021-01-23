    var l = new List<DateTime> {
        new DateTime(2014, 11, 11, 22, 0, 0),
        new DateTime(2014, 11, 11, 23, 45, 0),
        new DateTime(2014, 11, 11, 23, 55, 0),
        new DateTime(2014, 11, 11, 23, 59, 59),
        new DateTime(2014, 11, 12, 0, 0, 0),
        new DateTime(2014, 11, 12, 0, 4, 0),
        new DateTime(2014, 11, 12, 0, 15, 0),
        new DateTime(2014, 11, 12, 1, 0, 0),
        new DateTime(2014, 11, 12, 10, 0, 0),
    };
    for (int i = 0; i < l.Count - 1; i++) {
        if (l[i].TimeOfDay.TotalMinutes < 5 || l[i].TimeOfDay.TotalMinutes >= 23*60 + 55) 
            Console.WriteLine("{0} is close to midnight", l[i]);
        else
            Console.WriteLine("{0} is NOT close to midnight", l[i]);
    }
