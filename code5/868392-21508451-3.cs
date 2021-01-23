    public class WeatherData
    {
        //WeatherDatas
        public Data airtemp { get; set; }
        ...
    
        public WeatherData(string json, int index)
        {
            JObject jsonObject = JObject.Parse(json);
            JToken jObbs = jsonObject["observations"];
            JToken jData = jObbs["data"];            
            airtemp.Value = new Data((string)jData[index]["air_temp"], typeof(string));
            
            ...
        }
    }
