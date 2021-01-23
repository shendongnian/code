    public static class TimeSpanExtensions
    {
        public static TimeSpan RoundToNearestMinutes(this TimeSpan input, int minutes)
        {
            var halfRange = new TimeSpan(0, minutes/2, 0);
            if (input.Ticks < 0)
                halfRange = halfRange.Negate();
            var totalMinutes = (int)(input + halfRange).TotalMinutes;
            return new TimeSpan(0, totalMinutes - totalMinutes % minutes, 0);
        }
    }
