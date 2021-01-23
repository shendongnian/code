    var timeZoneName = "Pacific Standard Time";
    var currentTimezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
    var currentRules =
        currentTimezone.GetAdjustmentRules().FirstOrDefault(rule =>
            rule.DateStart <= DateTime.Today &&
            rule.DateEnd >= DateTime.Today);
    var daylightStart = new DateTime(DateTime.Today.Year, 
        currentRules.DaylightTransitionStart.Month,
        currentRules.DaylightTransitionStart.Day);
    var daylightEnd = new DateTime(DateTime.Today.Year, 
        currentRules.DaylightTransitionEnd.Month,
        currentRules.DaylightTransitionEnd.Day);
