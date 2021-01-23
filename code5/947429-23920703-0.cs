        string GetLocalDateTime(DateTime targetDateTime)
        {
            int fromTimezone = -3;
            int localTimezone;
            if (TimeZoneInfo.Local.BaseUtcOffset.Minutes != 0)
            {
                localTimezone = Convert.ToInt16(TimeZoneInfo.Local.BaseUtcOffset.Hours.ToString() + (TimeZoneInfo.Local.BaseUtcOffset.Minutes / 60).ToString());
            }
            else
            {
                localTimezone = TimeZoneInfo.Local.BaseUtcOffset.Hours;
            }
            DateTime Sdt = targetDateTime;
            DateTime UTCDateTime = targetDateTime.AddHours(-(fromTimezone));
            DateTime localDateTime = UTCDateTime.AddHours(+(localTimezone));
            return localDateTime.ToLongDateString() + " " + localDateTime.ToShortTimeString();
        }
