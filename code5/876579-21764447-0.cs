    public class TimeBlock
    {
		public DayOfWeek Day { get; set; }
		public LocalTime StartTime { get; set; }
		public LocalTime EndTime { get; set; }
		
		public TimeBlock(int day, int startTime, int endTime)
		{
			Day = (DayOfWeek)day;
			StartTime = new LocalTime(startTime / 100, startTime % 100);
			EndTime = new LocalTime(endTime / 100, endTime % 100);
		}
		public string GetDayOfWeekString()
		{
			return CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(Day);
		}
	}
