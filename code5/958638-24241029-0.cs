        public static DateTime CurrentTime()
        {
          
            DateTime dateTime = DateTime.Now;
            var timeZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, TimeZoneInfo.Local.Id, "India Standard Time"); // here you can mention the timeZone exactly.
            return timeZone;
        }
