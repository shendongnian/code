    public class JsonData
    {
      [JsonProperty("status")]
      public JObject Status{get;set;}
    
      [JsonProperty("geoLocation")]
      public JObject Location{get;set;}
    
    
      [JsonProperty("stations")]
      public List<JObject> Stations{get;set;}
    }
    public class FinalData
    {
      public Status StatusField{get;set;}
      public GeoLocation LocationField{get;set;}
      public List<Station> StationsList{get;set;}
    }
