    [JsonObject(MemberSerialization.OptIn)]
    public class User
    {
         [JsonProperty("initials")]
         public string Initials { get; set; }
         [JsonProperty("name")]
         public string Name { get; set; }
         [JsonProperty("companies")]
         public string[] Companies { get; set; }
         [JsonProperty("responseMessage")]
         public string ResponseMessage { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class ResponseData
    {
         [JsonProperty("user")]
         public User User { get; set; }
         [JsonProperty("employee")]
         public string Employee { get; set; }
    }
