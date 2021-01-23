    public class MessageStateResponse
    {
       [JsonProperty(PropertyName = "status", Order = 2)]
       public string Status { get; set; }
       [JsonProperty(PropertyName = "get_message_state", Order = 1)] 
       public Dictionary<string, string> Fields { get; set; }
    }
