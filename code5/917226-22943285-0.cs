	public class Schedule {
		public int ID { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		public int Minutes { get; set; }
	}
	
	public class ScheduleBlock : Schedule {
		public List<Schedule> Schedules { get; set; }
	}
