            DateTime firstDay = availableTimes[0].StartDate;
            DateTime previousTime = new DateTime(firstDay.Year, firstDay.Month, firstDay.Day, 0, 0, 0);
            List<Available> unavailableTimes = new List<Available>();
            foreach (Available available in availableTimes)
            {
                unavailableTimes.Add(new Available(previousTime, available.StartDate));
                previousTime = available.EndDate;
            }
            var dateTime = previousTime.Date;
            DateTime endDay = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
            unavailableTimes.Add(new Available(previousTime, endDay));
