    public static class DateTimeExtensions
    {
    	public static DayOfWeek AddDays(this DayOfWeek dayOfWeek, int count)
    	{
    		if (dayOfWeek < 0 || (int)dayOfWeek > 6) throw new ArgumentOutOfRangeException();
    
    		int adjustedValue = ((int)dayOfWeek + count) % 7;
    
    		return (DayOfWeek)(adjustedValue < 0 ? adjustedValue + 7 : adjustedValue);
    	}
    }
