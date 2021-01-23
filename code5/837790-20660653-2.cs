    class Program
    {
        static void Main(string[] args)
        {
            var dtString = "Tue Mar 13 12:00:00 EST 2012".ConvertTimeZone();
            DateTime dt;
            var success = DateTime.TryParseExact(
                dtString,
                "ddd MMM dd HH:mm:ss zzz yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dt);
            Console.WriteLine(success);
            if (Debugger.IsAttached) { Console.ReadKey(); }
        }
    }
    public static class Extensions
    {
        private static Dictionary<string, string> _timeZones =
            new Dictionary<string, string> { { "EST", "-05:00" } };
        public static string ConvertTimeZone(this string s)
        {
            var tz = s.Substring(20, 3);
            return s.Replace(tz, _timeZones[tz]);
        }
    }
