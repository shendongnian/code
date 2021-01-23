    public static TimeZoneInfo PosixToTzi(string posixTz)
    {
        var parts = posixTz.Split(',');
        var zoneparts = Regex.Split(parts[0], @"([0-9\+\-\.]+)");
        double baseOffsetHours;
        if (zoneparts.Length > 1)
        {
            if (!Double.TryParse(zoneparts[1], out baseOffsetHours))
                throw new FormatException();
        }
        else
        {
            // recognize RFC822 time zone abbreviations
            switch (zoneparts[0].ToUpper())
            {
                case "UT":
                case "UTC":
                case "GMT":
                    baseOffsetHours = 0;
                    break;
                case "EDT":
                    baseOffsetHours = 4;
                    break;
                case "EST":
                case "CDT":
                    baseOffsetHours = 5;
                    break;
                case "CST":
                case "MDT":
                    baseOffsetHours = 6;
                    break;
                case "MST":
                case "PDT":
                    baseOffsetHours = 7;
                    break;
                case "PST":
                    baseOffsetHours = 8;
                    break;
                default:
                    throw new FormatException();
            }
        }
        double dstOffsetHours = baseOffsetHours - 1;
        if (zoneparts.Length == 4)
        {
            if (!Double.TryParse(zoneparts[3], out dstOffsetHours))
                throw new FormatException();
        }
        var baseOffset = TimeSpan.FromHours(-baseOffsetHours);
        var dstDelta = TimeSpan.FromHours(baseOffsetHours - dstOffsetHours);
        var rules = new List<TimeZoneInfo.AdjustmentRule>();
        if (parts.Length == 3)
        {
            var rule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                DateTime.MinValue.Date, DateTime.MaxValue.Date, dstDelta,
                ParsePosixTransition(parts[1]), ParsePosixTransition(parts[2]));
            rules.Add(rule);
        }
        return TimeZoneInfo.CreateCustomTimeZone(posixTz, baseOffset, parts[0], zoneparts[0],
            zoneparts[zoneparts.Length == 3 ? 2 : 0], rules.ToArray());
    }
    private static TimeZoneInfo.TransitionTime ParsePosixTransition(string transition)
    {
        var parts = transition.Split('/');
        if (parts.Length > 2)
                throw new FormatException();
        double hours = 0;
        if (parts.Length == 2)
        {
            if (!Double.TryParse(parts[1], out hours))
                throw new FormatException();
        }
        var time = DateTime.MinValue.AddHours(hours);
        if (transition.StartsWith("M", StringComparison.OrdinalIgnoreCase))
        {
            var dateParts = parts[0].Substring(1).Split('.');
            if (dateParts.Length > 3)
                throw new FormatException();
            int month;
            if (!Int32.TryParse(dateParts[0], out month))
                throw new FormatException();
            int week;
            if (!Int32.TryParse(dateParts[1], out week))
                throw new FormatException();
            int dow;
            if (!Int32.TryParse(dateParts[2], out dow))
                throw new FormatException();
            return TimeZoneInfo.TransitionTime.CreateFloatingDateRule(time, month, week, (DayOfWeek) dow);
        }
        if (transition.StartsWith("J", StringComparison.OrdinalIgnoreCase))
        {
            int dayNum;
            if (!Int32.TryParse(parts[0].Substring(1), out dayNum))
                throw new FormatException();
            var date = DateTime.MinValue.AddDays(dayNum);
            return TimeZoneInfo.TransitionTime.CreateFixedDateRule(time, date.Month, date.Day);
        }
        throw new FormatException();
    }
