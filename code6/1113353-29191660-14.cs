    public class HourlyForecastData
    {
        public DateTime DateTime { get; }
        ...
        public HourlyForecastData(DateTime dateTime, ...)
        {
            // Get only auto properties can only be set at construction time
            DateTime = dateTime;
            ...
