    List<MyClass> lst3 = DateList.Select(p => new MyClass
            {
                DT = p,
                WeekOfYear = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(p , DateTimeFormatInfo.CurrentInfo.CalendarWeekRule, DayOfWeek.Monday),
                FirstDayOfWeek = p.AddDays(DayOfWeek.Monday - p.DayOfWeek),
                LastDayOfWeek = p.AddDays(DayOfWeek.Sunday - p.DayOfWeek)
            }).OrderBy(x=>x.WeekOfYear).ToList();
