    public class WeatherInfo
    {
        public WeatherInfo(string date, string tempLow, string tempHigh)
        {
            this.Date = date;
            this.TempLow = tempLow;
            this.TempHigh = tempHigh;
        }
        public string Date { get; private set; }
        public string TempLow { get; private set; }
        public string TempHigh { get; private set; }
    }
