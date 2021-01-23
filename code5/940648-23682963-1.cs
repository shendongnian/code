        private static readonly Dictionary<Tuple<string, string>, DateTime> lastUpdateDateTimes = new Dictionary<Tuple<string, string>, DateTime>();
        private static readonly Dictionary<string, TimeSpan> timeIntervals = new Dictionary<string, TimeSpan>();
        static MyClass()
        {
            timeIntervals.Add("s5", TimeSpan.FromSeconds(5));
            timeIntervals.Add("m1", TimeSpan.FromMinutes(1));
            timeIntervals.Add("h1", TimeSpan.FromHours(1));
            timeIntervals.Add("d1", TimeSpan.FromDays(1));
        }
        private static string GetInsertDataArgument(string instrument, string timeIntervalName)
        {
            string result = instrument.Replace("/", "").ToLower();
            if (timeIntervalName != "s5")
                result = result + timeIntervalName;
            return result;
        }
        private static void Update(string instrument)
        {
            DateTime now = DateTime.Now;
            foreach (var timeInterval in timeIntervals)
            {
                var dateTimeKey = new Tuple<string, string>(instrument, timeInterval.Key);
                if (now - lastUpdateDateTimes[dateTimeKey] < timeInterval.Value)
                    continue;
                lastUpdateDateTimes[dateTimeKey] = now;
                InsertData(GetInsertDataArgument(instrument, timeInterval.Key), data);
            }
        }
    }
