    static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<DateTime>> GetConsecutiveDays(this IEnumerable<DateTime> data,
                                                                            int consecutiveDayCount)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (consecutiveDayCount < 2)
            {
                throw new ArgumentException("consecutiveDayCount should be greater than 1");
            }
            
            var days = data.Select(item => item.Date).Distinct().OrderBy(item => item);
            return days.Select((day, index) => days.Skip(index).Take(consecutiveDayCount).ToList())
                       .Where(group => group.First().AddDays(consecutiveDayCount - 1) == group.Last());
        }
    }
