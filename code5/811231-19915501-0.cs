	public class EditSchoolyearDTO
	{
		public string Name { get; set; }
		public DateTime EndDate { get; set; }
		public WeekType StartWeek { get; set; }
		public enum WeekType : int
		{
			A = 0,
			AB = 1,
		}
		public int UserId { get; set; }
		public WeekTypeADTO SchoolWeekA { get; set; }
		public WeekTypeBDTO SchoolWeekB { get; set; }
	}
	public class WeekTypeADTO
	{
		public int MaxPeriodPerWeekA { get; set; }
		public IEnumerable<int> VisibleWeekDayIndexA;
		public DayOfWeek FirstDayOfWeekA { get; set; }
	}
	public class WeekTypeBDTO
	{
		public int WeeklyRotation { get; set; }
		public DayOfWeek FirstDayOfWeekB { get; set; }
		public IEnumerable<int> VisibleWeekDayIndexB;
		public int MaxPeriodPerWeekB { get; set; }
	}
