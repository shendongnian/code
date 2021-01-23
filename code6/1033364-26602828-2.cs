        private static void TestTimeZone()
        {
            var saving = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
            var datetime = new DateTime(saving.End.Year, saving.End.Month, saving.End.Day - 1);
            var utc = datetime.ToUniversalTime();
            var timeZone = TimeZone.CurrentTimeZone;
            for (var i = 0; i < 120; i++)
            {
                var next = timeZone.ToLocalTime(utc);
                Console.WriteLine(next);
                utc = utc.AddMinutes(30);
            }
        }
