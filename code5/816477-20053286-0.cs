    private static readonly LocalTime CutOff = new LocalTime(4, 0, 0);
    ...
    LocalDate date = dateTime.Date;
    if (dateTime.TimeOfDay < CutOff)
    {
        date = date.PlusDays(-1);
    }
    var dayOfWeek = date.IsoDayOfWeek;
