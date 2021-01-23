    using System;
    namespace ConsoleApplication2
    {
    class Program
    {
        static void Main(string[] args)
        {
            int[] savedDates = new int[] { 000000, 010000, 000013 };
            foreach (var item in savedDates)
            {
                DateTime date = ConvertToDate(item);
                Console.WriteLine(item.ToString("D6") + " => " + date.ToShortDateString());
            }
            Console.ReadLine();
        }
        private static DateTime ConvertToDate(int item)
        {
            string temp = item.ToString("D6");
            int day = int.Parse(temp.Substring(0, 2));
            int month = int.Parse(temp.Substring(2, 2));
            int year = int.Parse(temp.Substring(4, 2));
            if (day == 0)
                day = 1;
            if (month == 0)
                month = 1;
            year += 2000;
            return new DateTime(year, month, day);
        }
    }
    }
