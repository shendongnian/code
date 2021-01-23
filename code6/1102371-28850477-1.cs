	public class Program
	{	
		public static void Main()
		{
			var input = new List<P>
			{
				new P { StartDate = new DateTime(2015, 1, 1), EndDate = new DateTime(2015, 3, 31), Week = DayOfWeek.Monday, Year = 2015, percentage = 50 },
				new P { StartDate = new DateTime(2015, 1, 1), EndDate = new DateTime(2015, 6, 30), Week = DayOfWeek.Monday, Year = 2015, percentage = 80 },
				new P { StartDate = new DateTime(2015, 4, 1), EndDate = new DateTime(2015, 6, 30), Week = DayOfWeek.Monday, Year = 2015, percentage = 50 },
			};	
			
			var result = input.SelectMany(p => 
			{
				var weeks = Enumerable.Range(0, (p.EndDate - p.StartDate).Days / 7)
       								  .Select(i => CultureInfo.InvariantCulture.Calendar.AddWeeks(p.StartDate, i))
									  .Select(i => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(i, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
																
				return weeks.Select(w => new { Week = w, Percentage = p.percentage / weeks.Count() });
			})
			.GroupBy(x => x.Week)
     		.Select(g => new { Week = g.Key, Average = g.Average(t => t.Percentage) });
		}
	}
	
	public class P
	{
		public DateTime StartDate;
		public DateTime EndDate;
		public DayOfWeek Week;
		public int Year;
		public int percentage;
	}
