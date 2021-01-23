    public static class DateExtenders
            {
                public static DateTime UtcToLocal(this DateTime UtcDateTime, string TimezoneName)
                {
                    return
                        TimeZoneInfo.ConvertTimeFromUtc(UtcDateTime, TimeZoneInfo.GetSystemTimeZones().Where(tz => TimezoneName.MatchSubstring(tz.StandardName, false)).Single());
                }        
            }
