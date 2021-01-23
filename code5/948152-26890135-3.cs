            var timeZoneInfo = GetWorkaroundTimeZone(TimeZoneInfo.Local);
            var appointment = new Appointment(service)
                              {
                                  Subject = subject,
                                  Body = body,
                                  Start = start,
                                  StartTimeZone =  timeZoneInfo,
                                  End = end,
                                  EndTimeZone = timeZoneInfo
                              };
            
        private static TimeZoneInfo GetWorkaroundTimeZone(TimeZoneInfo timeZone)
        {
            try
            {
                TimeZoneInfo.ConvertTime(new DateTime(2014, 1, 1), timeZone, TimeZoneInfo.Utc);
                TimeZoneInfo.ConvertTime(new DateTime(2012, 1, 1), timeZone, TimeZoneInfo.Utc);
                TimeZoneInfo.ConvertTime(new DateTime(2009, 1, 1), timeZone, TimeZoneInfo.Utc);
                return TimeZoneInfo.Local;
            }
            catch (Exception ex)
            {
                return TimeZoneInfo.CreateCustomTimeZone(
                    "Time zone to workaround bug",
                    timeZone.BaseUtcOffset,
                    "Time zone to workaround bug",
                    "Time zone to workaround bug");
            }
        }
