    void Main()
    {
        Result result = new Result 
        {
            Data = new Data 
            {
                WeatherData = new List<City> 
                {
                    new City 
                    {
                        Name = "London",
                        Temp = new Dictionary<DateTime, TemperatureRange> 
                        {
                            { 
                                DateTime.UtcNow, 
                                new TemperatureRange 
                                {
                                    DayHigh = 0,
                                    MorningLow = 50
                                }
                            }
                        }
                    }
                }
            }       
        };
        
        JsonConvert.SerializeObject(result);
    }
    
    public class Result
    {
        [JsonProperty("result_content")]
        public Data Data { get; set; }
    }
    
    public class Data 
    {
        [JsonProperty("data")]
        public List<City> WeatherData { get; set; }
    }
    
    public class City
    {
        [JsonProperty("city_name")]
        public string Name { get; set; }
        
        public Dictionary<DateTime, TemperatureRange>  Temp { get; set; }
    }
    
    public class TemperatureRange
    {
        public int MorningLow { get; set; }
        public int DayHigh { get; set; }
    }
