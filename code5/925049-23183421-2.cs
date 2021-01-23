    public class SO23182879
    {
        public enum StarSign
        {
            Aquarius, Pisces, Aries, Taurus, Gemini, Cancer,
            Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn
        };
        static DateTime[] starSignStartDates = new DateTime[]
        {
            new DateTime(DateTime.Now.Year, 1, 20),
            new DateTime(DateTime.Now.Year, 2, 19),
            new DateTime(DateTime.Now.Year, 3, 21),
            new DateTime(DateTime.Now.Year, 4, 20),
            new DateTime(DateTime.Now.Year, 5, 21),
            new DateTime(DateTime.Now.Year, 6, 21),
            new DateTime(DateTime.Now.Year, 7, 23),
            new DateTime(DateTime.Now.Year, 8, 23),
            new DateTime(DateTime.Now.Year, 9, 23),
            new DateTime(DateTime.Now.Year, 10, 23),
            new DateTime(DateTime.Now.Year, 11, 22),
            new DateTime(DateTime.Now.Year, 12, 22),
            new DateTime(DateTime.Now.Year, 1, 20),
        };
        private class StarSignDateRange
        {
            public StarSign Sign { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }
        private List<StarSignDateRange> signStartDates = new List<StarSignDateRange>();
        public SO23182879()
        {
            int date = 0;
            foreach (StarSign sign in Enum.GetValues(typeof(StarSign)))
            {
                signStartDates.Add(new StarSignDateRange
                {
                    Sign = sign,
                    StartDate = starSignStartDates[date],
                    EndDate = starSignStartDates[date + 1]
                });
                ++date;
            }
        }
        public StarSign Sign(DateTime date)
        {
            return signStartDates.First(
                sd => date.Month == sd.StartDate.Month && date.Day >= sd.StartDate.Day ||
                      date.Month == sd.EndDate.Month && date.Day < sd.EndDate.Day
                                       ).Sign;
        }
        public void Test()
        {
            IList<DateTime> testDates = new List<DateTime>
            {
                new DateTime(2014,1,1),
                new DateTime(2014,1,19),
                new DateTime(2014,1,20),
                new DateTime(2014,4,19),
                new DateTime(2014,4,20),
                new DateTime(2014,12,21),
                new DateTime(2014,12,22),
                new DateTime(2014,12,31),
            };
            foreach (DateTime d in testDates)
                Console.WriteLine(string.Format("{0} is in {1}", d, Sign(d)));
        }
    }
