    {  
    "data": [    
    {      
    "id": "288560300",      
    "lang": "en", 
     
    "subratings":     {     
  
    "Cleanliness": "5",
    "Sleep Quality": "5",
    "Service": "5"
      }
    }
    ]}
    public void LoadJsonKeyValuePair(string json)
    {  
    Rootobject item = JsonConvert.DeserializeObject<Rootobject>(json);
    }
    public class Rootobject
    {
    [JsonProperty("data")]
    public List<Datum> data { get; set; }
    }
    public class Datum
    {
    [JsonProperty("id")]
    public string id { get; set; }
    [JsonProperty("lang")]
    public string lang { get; set; }
    [JsonProperty("subratings")]
    public Dictionary<string, object> subratings { get; set; }
    }
