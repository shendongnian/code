    private List<DateTime> ProcessDate(DateTime dtStartDate, DateTime targetDate, List<DayOfWeek> daysOfWeek)
            {
                DateTime dtLoop = dtStartDate;
                List<DateTime> dtRequiredDates = new List<DateTime>();
                for (int i = dtStartDate.DayOfYear; i < targetDate.DayOfYear; i++)
                {
                    foreach (DayOfWeek day in daysOfWeek)
                    {
                        if (dtLoop.DayOfWeek == day)
                        {
                            dtRequiredDates.Add(dtLoop);
                        }
                    }
                    dtLoop = dtLoop.AddDays(1);
                }
                return dtRequiredDates;
            }
