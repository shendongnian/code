    using System;
    
    public class Program
    {
        public static void Main()
        {
            string day1 = Console.ReadLine();
            string month1 = Console.ReadLine();
            string year1 = Console.ReadLine();
    
            string day2 = Console.ReadLine();
            string month2 = Console.ReadLine();
            string year2 = Console.ReadLine();
    
            DateTime date1 = new DateTime(year: int.Parse(year1), month: int.Parse(month1), day: int.Parse(day1));
            DateTime date2 = new DateTime(year: int.Parse(year2), month: int.Parse(month2), day: int.Parse(day2));
    
            TimeSpan ts = date2 - date1;
            Console.WriteLine("There are {0} days(s) or {1} hour(s) or {2} minute(s) between those dates", ts.TotalDays, ts.TotalHours, ts.TotalMinutes );
        }
    }
