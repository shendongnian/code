    public class Payload
    {
        [JsonProperty("solarforecast")]
        public Dictionary<int, Dictionary<DateTime, SolarForecastTimeSet>> SolarForecast;
    }
    public class SolarForecastTimeSet
    {
        [JsonProperty("dh")]
        public decimal DiffusRadiationHorizontal;
        [JsonProperty("bh")]
        public decimal DirectRadiationHorizontal;
    }
