    public class OutputCacheMidnightAttribute : OutputCacheAttribute
    {
        public OutputCacheMidnightAttribute()
        {
            // remaining time to midnight
            Duration = (int)((new TimeSpan(24, 0, 0)) - DateTime.Now.TimeOfDay).TotalSeconds;
        }
    }
