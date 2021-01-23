        public DateTime DayOfArrival(DateTime startDate, int numberOfWordkingDays )
    {
        var result = startDate;
        var counter = 0;
        while (counter < numberOfWordkingDays)
        {
            if (result.DayOfWeek != DayOfWeek.Saturday &&
                result.DayOfWeek != DayOfWeek.Sunday)
            {
                counter++;
            }
            result = result.AddDays(1);
        }
        return result;
    }
