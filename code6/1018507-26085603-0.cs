    DateTime StartDate = Convert.ToDateTime("01/1/2010"); 
    DateTime EndDate = Convert.ToDateTime("04/3/2011");
    string strResult = CalculateDays(StartDate, EndDate);
    
    public string CalculateDays(DateTime StartDate, DateTime EndDate)
    {
    DateTime oldDate;
    
    DateTime.TryParse(StartDate.ToShortDateString(), out oldDate);
    DateTime currentDate = EndDate;
    
    TimeSpan difference = currentDate.Subtract(oldDate);
    
    // This is to convert the timespan to datetime object
    DateTime DateTimeDifferene = DateTime.MinValue + difference;
    
    // Min value is 01/01/0001
    // subtract our addition or 1 on all components to get the 
    //actual date.
    
    int InYears = DateTimeDifferene.Year - 1;
    int InMonths = DateTimeDifferene.Month - 1;
    int InDays = DateTimeDifferene.Day - 1;
    
    
    return InYears.ToString() +" Years "+ InMonths.ToString() +" Months " + InDays.ToString() +" Days";
    }
