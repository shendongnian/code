    public class Event
    {
                [JsonProperty(PropertyName = "_id")]
                public string Id { get; set; }
                [JsonProperty(PropertyName = "status"]
                public dynamic Status { get; set; }
    }
