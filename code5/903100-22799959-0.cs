    List<TimeZoneInfo> viableTimezones = new List<TimeZoneInfo>();
                foreach (TimeZoneInfo timeZone in timeZones)
                {
                    TimeSpan q = new TimeSpan(givenTimespawn);
                    if (timeZone.BaseUtcOffset == q && timeZone.DisplayName.Contains(CityVenue))
                    {
                        viableTimezones.Add(timeZone);
                    }
                }
    var endDate = new DateTime(Year, Month, Day, Hour, min, secs );
    var actualEndUTC = TimeZoneInfo.ConvertTimeToUtc(endDate, viableTimezones[0]);
            
