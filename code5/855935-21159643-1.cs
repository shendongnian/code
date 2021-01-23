    public double GetUsedVacation(int year)
     {
        double hours = 0;
        IEnumerable<HtVacationDay> vacationDays = 
            HtVacationDays.Where(x => x.FromDate.Year == year && 
                                      x.FromDate < DateTime.Today);
        DateTime firstDayOfYear = new DateTime(year, 1, 1);
        DateTime lastDayOfYear = new DateTime(year, 12, 31);
        foreach (HtVacationDay vacation in vacationDays)
        {
            DateTime from = vacation.FromDate.Date < firstDayOfYear ?
                  firstDayOfYear : vacation.FromDate;
            DateTime to = vacation.ToDate.Date > lastDayOfYear ?
                  lastDayOfYear : vacation.ToDate;
            var vacationHours = (to - from).TotalHours;            
            if (vacationHours > 8)            
                hours += vacationHours / 3;            
            else            
                hours += vacationHours;            
        }
        return hours / 8;
    }
