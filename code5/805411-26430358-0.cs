    class Program
    {
        static void Main()
        {
            DateTime oldDate = new DateTime(2014,1,1);
            DateTime newDate = DateTime.Now;
            TimeSpan dif = newDate - oldDate;
            int leapdays = GetLeapDays(oldDate, DateTime.Now);
            var years = (dif.Days-leapdays) / 365;
            int otherdays = GetAnOtherDays(oldDate, DateTime.Now, years);
            int months = (int)((dif.Days - (leapdays + otherdays)- (years * 365)) / 30);
            int days = (int)(dif.Days - years * 365 - months * 30) - (leapdays + otherdays);
            Console.WriteLine("Edad es {0} años, {1} meses, {2} días", years, months, days) ;
            Console.ReadLine();
        }
        public static int GetAnOtherDays(DateTime oldDate, DateTime newDate, int years) {
            int days = 0;
            oldDate = oldDate.AddYears(years);
            DateTime oldDate1 = oldDate.AddMonths(1);
            while ((oldDate1.Month <= newDate.Month && oldDate1.Year<=newDate.Year) || 
                (oldDate1.Month>newDate.Month && oldDate1.Year<newDate.Year)) {
                days += ((TimeSpan)(oldDate1 - oldDate)).Days - 30;
                oldDate = oldDate.AddMonths(1);
                oldDate1 = oldDate.AddMonths(1);
            }
            return days;
        }
        public static int GetLeapDays(DateTime oldDate, DateTime newDate)
        {
            int days = 0;
            while (oldDate.Year < newDate.Year) {
                if (DateTime.IsLeapYear(oldDate.Year)) days += 1;
                oldDate = oldDate.AddYears(1);
            }
            return days;
        }
    }
