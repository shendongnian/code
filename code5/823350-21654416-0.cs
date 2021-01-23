    public static class TimeSpanextensions
	{
		public static IEnumerable<DateTime> GetDays(this DateTime start, DateTime end, bool returnWeekDays = false)
		{
			List<DateTime> daysInSpan = new List<DateTime>();
			//change following line to accomodate date format if needed
			TimeSpan ts = start.Date - end.Date;
			if(start < end)
			{
				DateTime _this = start;
				while (_this < end) 
				{
					_this = start.AddDays(1);
					daysInSpan.Add(_this);
				}
			}
			if(start > end)
			{
				DateTime _this = start;
				while(_this > end)
				{
					_this = _this.AddDays(-1);
					daysInSpan.Add(_this);
				}
			}
			if(returnWeekDays)
			{
				return daysInSpan.Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday);
			}
			return daysInSpan;
		}
