    private bool DatesAreInTheSameWeek(DateTime birthday)
        {
            if (birthday == DateTime.MinValue)
            {
                return false;
            }
            else
            {
                var birtdayWithCurrentYear = new DateTime(DateTime.Today.Year, birthday.Month, birthday.Day);
                // the below if condition is used to check when the dates are between last week of dec and 1st week of jan
                if (birthday.Month == 1 && DateTime.Today.Month != 1)
                {
                    birtdayWithCurrentYear = birtdayWithCurrentYear.AddYears(1);
                }
                DateTime firstDayInWeek = DateTime.Today.Date;
                while (firstDayInWeek.DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek)
                    firstDayInWeek = firstDayInWeek.AddDays(-1);
                var lastDayInWeek = firstDayInWeek.AddDays(7);
                return birtdayWithCurrentYear < lastDayInWeek && birtdayWithCurrentYear >= firstDayInWeek;
            }
        }
