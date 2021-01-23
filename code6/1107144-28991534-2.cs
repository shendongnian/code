    DateRange[] dateRanges = new[] 
    { 
        new DateRange(new DateTime(2015, 6, 7), new DateTime(2015, 12, 2)),
        new DateRange(new DateTime(2015, 12, 03), new DateTime(2016, 03, 02)),
        new DateRange(new DateTime(2014, 11, 21), new DateTime(2015, 6, 6)),
    };
    bool res = IsFullRange(dateRanges, 2015);
