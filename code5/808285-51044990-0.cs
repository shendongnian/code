        public void GetMonths(DateTime startTime, DateTime endTime)
        {
            var dateCounter = new DateTime(startTime.Year, startTime.Month, 1);
            var endDateTarget = new DateTime(endTime.Year, endTime.Month, 1);
            
            while (dateCounter <= endDateTarget)
            {
                Console.WriteLine($"The year and month is: {dateCounter.Year}, {dateCounter.Month}");
                dateCounter = dateCounter.AddMonths(1);
            }
        }
