	public static class DateTimeExtensionMethods
	{
		public static DateTime StartOfMonth(this DateTime date)
		{
			return new DateTime(date.Year, date.Month, 1);
		}
		public static DateTime EndOfMonth(this DateTime date)
		{
			return date.StartOfMonth().AddMonths(1).AddSeconds(-1);
		}
	}
