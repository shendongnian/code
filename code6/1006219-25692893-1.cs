    public class Program
	{
		public static void Main()
		{
			var myobject = new MyObject();
			myobject.Calendars1 = new List<Calendar>();
			for (DateTime dt = new DateTime(1980,1,1); dt <= new DateTime(1981,1,1); dt = dt.AddMonths(1))
			{
				myobject.Calendars1.Add(new Calendar() { Name =  dt.ToString("MMMM") });
			}
			
			myobject.Calendars2 = myobject.Calendars1.ToArray();
			
			var json1 = JsonConvert.SerializeObject(myobject.Calendars1);
			var json2 = JsonConvert.SerializeObject(myobject.Calendars1);
			
			Console.WriteLine(json1);
			Console.WriteLine(json2);
		}
	}
	
	public class MyObject
	{
		public List<Calendar> Calendars1 { get; set; }
		public Calendar[] Calendars2 { get; set; }
	}
	
	public class Calendar
	{
		public string Name { get; set; }
	}
