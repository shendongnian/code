	// slightly updated Event class
	public class Event
	{
		public int ID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public DayOfWeek[] DayOfWeekList { get; set; }
		public string Title { get; set; }
	}
	var startDate = new DateTime(2013, 9, 1);
	var endDate = new DateTime(2013, 9, 16);
	var totalDays = (int)endDate.Subtract(startDate).TotalDays + 1;
	
	// sample data, including a 4th event starting a while ago with no end date
	var events = new List<Event> {
		new Event { ID = 1, Title = "Event 1", StartDate = new DateTime(2013, 9, 15), EndDate = new DateTime(2013, 9, 15), DayOfWeekList = new[] { DayOfWeek.Sunday } },
		new Event { ID = 2, Title = "Event 2", StartDate = new DateTime(2013, 9, 15), EndDate = new DateTime(2013, 9, 16), DayOfWeekList = new[] { DayOfWeek.Sunday, DayOfWeek.Monday } },
		new Event { ID = 3, Title = "Event 3", StartDate = new DateTime(2013, 9, 1), EndDate = new DateTime(2013, 9, 30), DayOfWeekList = new[] { DayOfWeek.Tuesday, DayOfWeek.Thursday } },
		new Event { ID = 4, Title = "Event 4", StartDate = new DateTime(2013, 1, 1), EndDate = null, DayOfWeekList = new[] { DayOfWeek.Wednesday } },
	};
	
	var eventsInRange = events.Where(e => e.StartDate <= endDate && (e.EndDate == null || e.EndDate.Value >= startDate ));
	
	var daysInRange = Enumerable.Range(0, totalDays).Select(i => startDate.AddDays(i));
	
	var eventInstances = from d in daysInRange
		from e in eventsInRange
		where (e.EndDate == null || d <= e.EndDate.Value) && d >= e.StartDate && e.DayOfWeekList.Contains(d.DayOfWeek)
		select new {
			Date = d,
			Event = e,
		};
