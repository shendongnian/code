    public struct HourlyForecastDataState
    {
        public DateTime DateTime;
        public decimal TemperatureCelcius;
        public decimal DewPoint;
        public string Condition;
        public int ConditionCode;
        public int WindSpeed;
        public string WindDirection;
        public decimal WindDegrees;
        public int UltravioletIndex;
        public decimal Humidity;
        public decimal WindChill;
        public int HeatIndex;
        public decimal FeelsLike;
        public decimal Snow;
    }
    public class HourlyForecastData
    {
        public DateTime DateTime { get; private set; }
        public decimal TemperatureCelcius { get; private set; }
        public decimal DewPoint { get; private set; }
        public string Condition { get; private set; }
        public int ConditionCode { get; private set; }
        public int WindSpeed { get; private set; }
        public string WindDirection { get; private set; }
        public decimal WindDegrees { get; private set; }
        public int UltravioletIndex { get; private set; }
        public decimal Humidity { get; private set; }
        public decimal WindChill { get; private set; }
        public int HeatIndex { get; private set; }
        public decimal FeelsLike { get; private set; }
        public decimal Snow { get; private set; }
        public HourlyForecastData(HourlyForecastDataState state)
        {
            DateTime = state.dateTime;
            TemperatureCelcius = state.temperatureCelcius;
            //...etc
        }
    }
