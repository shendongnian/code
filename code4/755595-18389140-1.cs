    var lines = webData.Split('\n');
    var allData = lines.Skip(1).Take(lines.Length - 2).Select(x => new WeatherData(x));
    var latestDate = allData.Max(x => x.DateTime);
    var latestAirTemp = allData.First(x => x.DateTime == latestDate).AirTemp;
    public class WeatherData
    {
        public DateTime DateTime { get; set; }
        public decimal AirTemp { get; set; }
        public decimal SoilTemp { get; set; }
        public int Humidity { get; set; }
        public WeatherData(string rawData)
        {
            // implement
        }
    }
