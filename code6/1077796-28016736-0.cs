	class Program
	{
		static void Main(string[] args)
		{
			var sessions = new List<InfoSessions>();
			sessions.Add(new InfoSessions("South Pole", new DateTime(2015, 01, 01)));
			sessions.Add(new InfoSessions("Melbourne", new DateTime(2015, 03, 24)));
			sessions.Add(new InfoSessions("HongKong", new DateTime(2015, 02, 14)));
			sessions.Add(new InfoSessions("Singapore", new DateTime(2015, 04, 14)));
			sessions.Add(new InfoSessions("Sydney", new DateTime(2015, 05, 18)));
			sessions.Add(new InfoSessions("Auckland", new DateTime(2015, 08, 18)));
			var orderSessions = sessions.Where(x => x.Date > DateTime.Now)
										.OrderByDescending(x => x.Date)
										.ToList();
			orderSessions.ForEach(x=> Console.WriteLine("Location: {0}, Date: {1}", x.Place, x.Date));
			Console.ReadKey();
		}
	}
	public class InfoSessions
	{
		public String Place { get; set; }
		public DateTime Date { get; set; }
		public InfoSessions(String place, DateTime date)
		{
			Place = place;
			Date = date;
		}
	}
