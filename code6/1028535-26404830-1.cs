    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new DateTime(2000, 01, 01, 12, 24, 48);
            DateTime? d2 = new DateTime(2000, 01, 01, 07, 29, 31);
            
            Console.WriteLine((d1.Date == ((DateTime)d2).Date));
            Console.WriteLine((d1.CompareDate(d2)));
            Console.WriteLine((d1.CompareDate(null)));
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
    }
    static class DateCompare
    {
        public static bool CompareDate(this DateTime dtOne, DateTime? dtTwo)
        {
            if (dtTwo == null) return false;
            return (dtOne.Date == ((DateTime)dtTwo).Date);
        }
    }
