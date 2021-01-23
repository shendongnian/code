    DateTime nextMonthfirstSunday;
            DayOfWeek firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1).DayOfWeek;
            switch (firstDay)
            {
                case DayOfWeek.Sunday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month+1, 1);
                    break;
                case DayOfWeek.Monday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 7);
                    break;
                case DayOfWeek.Tuesday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 6);
                    break;
                case DayOfWeek.Wednesday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 5);
                    break;
                case DayOfWeek.Thursday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 4);
                    break;
                case DayOfWeek.Friday:
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 3);
                    break;
                default://Saturday
                    nextMonthfirstSunday = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 2);
                    break;
            }
