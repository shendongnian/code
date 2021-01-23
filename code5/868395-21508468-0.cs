    public class UserString
    {
        public Type _type{ get; set; }
        public string value{ get; set; }
        
        public UserString()
    {
       _type = null;
       value = string.Empty;
    }
    }
    
    public class WeatherData
    {
        //WeatherDatas
        public UserString airtemp { get; set; }
        public UserString apparenttemp { get; set; }
        public UserString windspeedkph { get; set; }
        public UserString windgustskph { get; set; }
        public UserString humidity { get; set; }
        public UserString dewpoint { get; set; }
        public UserString deltaT { get; set; }
        public UserString pressure { get; set; }
    
        public WeatherData(string json, int index)
        {
            JObject jsonObject = JObject.Parse(json);
            JToken jObbs = jsonObject["observations"];
            JToken jData = jObbs["data"];            
            airtemp.value = (string)jData[index]["air_temp"];
    //        airtemp._type = typeof(string); //Something like that.
            apparenttemp = (string)jData[index]["apparent_t"];
            windspeedkph = (string)jData[index]["wind_spd_kmh"];
            windgustskph = (string)jData[index]["gust_kmh"];
            humidity = (string)jData[index]["rel_hum"];
            pressure = (string)jData[index]["press_qnh"];
        }
    }
