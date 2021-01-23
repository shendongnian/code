        enum StarSign { Aquarius, Pisces, Aries, Taurus, /*etc */};
        DateTime[] startDates = new DateTime[]
        {
            new DateTime(0,1,21),
            new DateTime(0,2,20),
            new DateTime(0,3,21),
            new DateTime(0,4,21),
             /* etc */
        };
        Dictionary<DateTime, StarSign> signStartDates;
        static StarSign Sign(DateTime date)
        {
            return signStartDates.First(sd =>
                                          sd.Key.Month <= date.Month &&
                                          sd.Key.Day <= date.Day)
                                 .Value;
        }
