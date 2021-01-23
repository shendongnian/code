	void Main()
	{
		var dateList = new List<DateLookupItem>();
		for(int i=0; i< 100; ++i) dateList.Add(new UserQuery.DateLookupItem());
		
		var sameDates = from d in dateList
				group d.Description by d.Date.Date;
	
		var displayDate = 
			String.Join(",", 
						sameDates
						.Select(date=>string.Format("({0}) {1}", String.Join("/", date), date.Key)));
		
		
		displayDate.Dump();
	}
	
	
	public class DateLookupItem
	{
		static readonly Random rnd = new Random();
			public DateLookupItem()
			{
				Id = rnd.Next();
				Date = DateTime.Now.AddDays(rnd.Next(-5, 5) );
				Description = new string((char) rnd.Next(65, 91), rnd.Next(10)+1);
			}
		public int Id {get; set;}
		public DateTime Date {get; set;}
		public string Description {get; set;}
	}
