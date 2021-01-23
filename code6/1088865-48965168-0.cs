    public static class DateTimeExtensions
	{
		public static DateTime AddHalfMonth(this DateTime dt)
		{
			int daysInMonth = System.DateTime.DaysInMonth(dt.Year, dt.Month);
			if (daysInMonth % 2 == 0 || dt.Day < daysInMonth / 2)
			{
				return dt.AddDays(daysInMonth / 2);
			}
		
			return dt.AddDays((daysInMonth + 1) / 2);
		}
	}
