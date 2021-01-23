    public static class DateTimeDayOfMonthExtensions
    {
    	public static DateTime FirstDayOfMonth(this DateTime value)
    	{
    		return new DateTime(value.Year, value.Month, 1);
    	}
    	
    	public static int DaysInMonth(this DateTime value)
    	{
    		return DateTime.DaysInMonth(value.Year, value.Month);
    	}
    	
    	public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.DaysInMonth());
        }
    }
