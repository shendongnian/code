    [DataContract(Name = "response", Namespace = "")]
    public class WeatherData
    {
        [DataMember(Name = "forecast")]
        public Forecast Forecast { get; set; }
    }
    [DataContract(Name = "forecast", Namespace = "")]
    public class Forecast
    {
        [DataMember(Name = "txt_forecast")]
        public TxtForecast TxtForecast { get; set; }
    }
    [DataContract(Name = "txt_forecast", Namespace = "")]
    public class TxtForecast
    {
        [DataMember(Name = "forecastdays")]
        public ForecastDay[] ForecastDays { get; set; }
    }
    [DataContract(Name = "forecastday", Namespace = "")]
    public class ForecastDay
    {
        [DataMember(Name = "period", Order = 1)]
        public int Period { get; set; }
        public string FctText { get; set; }
        [DataMember(Name = "fcttext", EmitDefaultValue = false, Order = 5)]
        private CDataWrapper FctTextWrapper
        {
            get { return FctText; }
            set { FctText = value; }
        }
    }
