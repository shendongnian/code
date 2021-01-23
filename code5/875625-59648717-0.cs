public static DateTime Round(this DateTime date, long ticks = TimeSpan.TicksPerSecond) {
    if (ticks>1)
    {
        var frac = date.Ticks % ticks;
        if (frac != 0)
        {
            // Rounding is needed..
            if (frac*2 >= ticks)
            {
                // round up
                return new DateTime(date.Ticks + ticks - frac);
            }
            else
            {
                // round down
                return new DateTime(date.Ticks - frac);
            }
        }
    }
    return date;
}
It can be used like this:
DateTime now = DateTime.Now;
DateTime nowTrimmedToSeconds = now.Round(TimeSpan.TicksPerSecond);
DateTime nowTrimmedToMinutes = now.Round(TimeSpan.TicksPerMinute);
