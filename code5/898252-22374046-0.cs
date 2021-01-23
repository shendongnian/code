        private List<DateTime> GetDates(DateTime startDate, DateTime endDate, DayOfWeek dayOfWeek)
        {
            var returnDates = new List<DateTime>();
            for (DateTime dateCounter = startDate; dateCounter < endDate; dateCounter = dateCounter.AddDays(1))
            {
                if (dateCounter.DayOfWeek == dayOfWeek)
                {
                    returnDates.Add(dateCounter);
                }
            }
            return returnDates;
        }
