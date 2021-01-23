    public void CountMondays(DateTime start, DateTime end){
        int mondays = 0;
        for(DateTime date = start;date <= end; date=date.AddDays(1)){
            if(date.DateOfWeek == DayOfWeek.Monday)
                mondays++;
        }
        return mondays;
    }
