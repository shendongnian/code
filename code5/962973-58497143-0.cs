    public static bool IsDaylightSavingsTime(this DateTimeOffset dateTimeOffset)
            {
                var timezone = "Europe/London"; //https://nodatime.org/TimeZones
                ZonedDateTime timeInZone = dateTimeOffset.DateTime.InZone(timezone);
                var instant = timeInZone.ToInstant();
                var zoneInterval = timeInZone.Zone.GetZoneInterval(instant);
                return zoneInterval.Savings != Offset.Zero;
            }
