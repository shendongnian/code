    var groups = data.GroupBy(v => new {Year = v.TimeRecorded.Year,
										Season = SeasonFromMonth(v.TimeRecorded.Month),
										Month = v.TimeRecorded.Month,
										Week = System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(v.TimeRecorded, System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Monday),
										Day = v.TimeRecorded.Day});
