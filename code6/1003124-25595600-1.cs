    // Usually inject this, using SystemClock.Instance for production
    IClock clock = ...; 
    // For the UK, use DateTimeZoneProviders.Tzdb["Europe/London"];
    DateTimeZone zone = ...; 
    // This will be simpler in Noda Time 2.0 with ZonedClock
    LocalDate today = clock.Now.InZone(zone).LocalDateTime.Date;
    int taxYear = today.Month > 4 || today.Month == 4 && today.Day >= 6
        ? today.Year : today.Year - 1;
    LocalDate taxYearStart = new LocalDate(taxYear, 4, 6);
    int days = Period.Between(taxYearStart, today, PeriodUnits.Days).Days;
    int taxYearWeek = (days / 7) + 1;
    
