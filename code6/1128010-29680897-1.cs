    //Represents the data needed for each marker, with JSON.NET attributes to account for different property names we want to use in the JSON
    public class Marker
    {
        [JsonProperty(PropertyName = "title")]
        public string Title {get; set;}
    
        [JsonProperty(PropertyName = "lat")]
        public string Latitude {get; set;}
    
        [JsonProperty(PropertyName = "lng")]
        public string Longitude {get; set;}
    }
