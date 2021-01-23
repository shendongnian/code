    public class MyData{ 
      [JsonProperty("locations")]
      public Dictionary<string, Location> Locations {get;set;} 
    }
    public class Location
    {
      public string street1 { get; set; }
      public string street2 { get; set; }
      public string city { get; set; }
      public string state { get; set; }
      public string postal_code { get; set; }
      public string s_status { get; set; }
      public string system_state { get; set; }
    }
