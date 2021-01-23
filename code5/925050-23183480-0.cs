    enum StarSign { Aquarius, Pisces, Aries, Taurus, /*etc */};
    DateTime[] startDates = new DateTime[]
    {
        new DateTime(0,1,21),
        new DateTime(0,2,20),
        new DateTime(0,3,21),
        new DateTime(0,4,21),
        /* etc */
    };
    static StarSign Sign(DateTime inDate)
    {
       return StarSign.Zip((s, d) => new { sign = s, date = d })
                      .Where(x => x.s.Month <= x.d.Month && x.s.Day <= x.d.Day)
                      .Select(x => x.s)
                      .First();
    }
  
