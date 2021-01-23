    // Untested and quickly hacked up. Lots more API you'd probably
    // want, string conversions, properties etc.
    public sealed class Period
    {
        private readonly int years, months, days, hours, minutes, seconds;
        public Period(int years, int months, int days,
                      int hours, int minutes, int seconds)
        {
            this.years = years;
            this.months = months;
            this.days = days;
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public static DateTime operator+(DateTime lhs, Period rhs)
        {
            // Note: order of operations is important here.
            // Consider January 1st + (1 month and 30 days)...
            // what do you want the result to be?
            return lhs.AddYears(rhs.years)
                      .AddMonths(rhs.months)
                      .AddDays(rhs.days)
                      .AddHours(rhs.hours)
                      .AddMinutes(rhs.minutes)
                      .AddSeconds(rhs.seconds);
        }
    }
