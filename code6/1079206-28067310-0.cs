    var localDateTime = new LocalDate(2000, 1, 10).AtMidnight();
    var period = new PeriodBuilder {
        Years = 11, Months = 2, Days = 5,
        Hours = 10, Minutes = 10, Seconds = 11
    }.Build();
    var result = localDateTime + period;
