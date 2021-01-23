    public class RootObject
    {
    public RootObject(){}
    public Status status {get;set;}
    public GeoLocation GeoLocation {get;set;}
    public List<Stations> Stations {get;set;}
    }
    
    public class Status
    {
    public Status(){}
    
    [JsonProperty("error")]
    public string Error {get;set;}
    //all properties
    }
    
    public class GeoLocation
    {
    public GeoLocation{get;set;}
    
    [JsonProperty("city_id")]
    public int CityId {get;set;}
    //all properties
    }
    
    public class Station
    {
    public Station(){}
    // all properties just like previous classes
    }
