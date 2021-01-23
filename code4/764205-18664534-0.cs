    public static class DatesExtensions {
        public static DateTime ToDateTime(this LocalDate localDate) {
            return new DateTime(localDate.Year, localDate.Month, localDate.Day);
        }
        public static LocalDate ToLocalDate(this DateTime dateTime) {
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }
        public static string Serialize(this ZonedDateTime zonedDateTime) {
            return LocalDateTimePattern.ExtendedIsoPattern.Format(zonedDateTime.LocalDateTime) + "@O=" + OffsetPattern.GeneralInvariantPattern.Format(zonedDateTime.Offset) + "@Z=" + zonedDateTime.Zone.Id;
        }
        public static ZonedDateTime DeserializeZonedDateTime(string value) {
            var match = ZonedDateTimeRegex.Match(value);
            if (!match.Success) throw new InvalidOperationException("Could not parse " + value);
            var dtm = LocalDateTimePattern.ExtendedIsoPattern.Parse(match.Groups[1].Value).Value;
            var offset = OffsetPattern.GeneralInvariantPattern.Parse(match.Groups[2].Value).Value;
            var tz = DateTimeZoneProviders.Tzdb.GetZoneOrNull(match.Groups[3].Value);
            return new ZonedDateTime(dtm, tz, offset);
        }
        public static readonly Regex ZonedDateTimeRegex = new Regex(@"^(.*)@O=(.*)@Z=(.*)$");
    }
    
