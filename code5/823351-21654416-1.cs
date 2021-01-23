    public static IEnumerable<DateTime> WeekDays(DateTime one, DateTime two)
		{
			TimeSpan test = one - two;
			return one.GetDays(two, true).ToList();
		}
