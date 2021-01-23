    using System;
						
	public class Program
	{
		public static void Main()
		{
			string month1 = Console.ReadLine();
			string day1 = Console.ReadLine();
			string year1 = Console.ReadLine();
			
			string month2 = Console.ReadLine();
			string day2 = Console.ReadLine();
			string year2 = Console.ReadLine();
	
			DateTime date1 = DateTime.Parse(string.Format("{0}/{1}/{2}", month1, day1, year1));
			DateTime date2 = DateTime.Parse(string.Format("{0}/{1}/{2}", month2, day2, year2));
			
			TimeSpan ts = date2 - date1;
			Console.WriteLine("There are {0} days(s) or {1} hour(s) or {2} minute(s) between those dates", ts.TotalDays, ts.TotalHours, ts.TotalMinutes );
		}
	}
