    class Program
    {
        static void Main(string[] args)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar calendar = dfi.Calendar;
            var week = calendar.GetWeekOfYear(DateTime.Now.AddDays(1), CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            Console.Write(week);
            Console.ReadLine();
        }
    }
