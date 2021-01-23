    private static DateTime Next(int year, int month, DayOfWeek dayOfWeek, int occurrence)
            {
                return Enumerable.Range(1, 7).
                            Select(day => new DateTime(year, month, day)).
                            First(dateTime => (dateTime.DayOfWeek == dayOfWeek))
                            .AddDays(7 * (occurrence - 1));
            }
