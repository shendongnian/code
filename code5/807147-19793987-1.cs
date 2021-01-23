    void Main()
    {
        var birthdays = new List<DateTime>();
    	birthdays.Add(new DateTime(2013, 11, 08));
    	birthdays.Add(new DateTime(2012, 05, 05));
    	birthdays.Add(new DateTime(2014, 05, 05));
    	birthdays.Add(new DateTime(2005, 11, 08));
    	birthdays.Add(new DateTime(2004, 12, 31));
    
    						
        foreach(var date in birthdays){
    	 if(date.IsWithinRange(twoDaysAgo, MonthAway)) {
    	  Console.WriteLine (date);
    	 }
    	}				
    }
    
    public static class Extensions {
    	public static bool IsWithinRange(this DateTime @this, DateTime lower, DateTime upper){
     		if(lower.DayOfYear > upper.DayOfYear){
    			return (@this.DayOfYear > lower.DayOfYear || @this.DayOfYear < upper.DayOfYear);
    		} 
    		
    		return (@this.DayOfYear > lower.DayOfYear && @this.DayOfYear < upper.DayOfYear);
    	}
    }
