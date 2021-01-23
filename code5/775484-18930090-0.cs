    class Program
    {
        static void Main(string[] args)
        {
            DateTimeOffset startTime, endTime, current = DateTimeOffset.Now;
            Console.WriteLine("Enter the Start Time (in Eastern Standard Time)");
            var inputStartTime = Console.ReadLine();
            Console.WriteLine("Enter the End Time (in Eastern Standard Time)");
            var inputEndTime = Console.ReadLine();
            if (!TryParseTimeAsEst(inputStartTime, out startTime))
            {
                Console.WriteLine("Start time is invalid");
                return;
            }
            if (!TryParseTimeAsEst(inputEndTime, out endTime))
            {
                Console.WriteLine("End time is invalid");
                return;
            }
            var currentUtc = current.UtcDateTime;
            if (startTime.UtcDateTime <= ccurrentUtc && currentUtc <= endTime.UtcDateTime)
            {
                Console.WriteLine("{0} is between {1} and {2}", current, startTime, endTime);
            }
            else
            {
                Console.WriteLine("{0} is NOT between {1} and {2}", current, startTime, endTime);
            }
        }
        static bool TryParseTimeAsEst(string value, out DateTimeOffset time)
        {
            var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var today = DateTime.Today;
            var nowUtc = DateTime.UtcNow; // need this to generate the offset that respects DST
            try
            {
                var t = TimeSpan.Parse(value); // parse the input into time
                time = new DateTimeOffset(today.Year, today.Month, today.Day, t.Hours, t.Minutes, t.Seconds, est.GetUtcOffset(nowUtc)); // create a datetime with offset that reflects DST
                return true;
            }
            catch
            {
                time = DateTimeOffset.MinValue;
                return false;
            }
        }
    }
