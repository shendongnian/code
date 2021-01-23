        LocalDate ld1 = new LocalDate(2012, 1, 1);
        LocalDate ld2 = new LocalDate(2013, 12, 25);
        Period period = Period.Between(ld1, ld2, PeriodUnits.Days);
        long days = period.Days;
        
