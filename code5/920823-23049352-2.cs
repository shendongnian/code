    public class Tbody2
    {
         [JsonProperty]
         [JsonConverter(typeof (ObjectToArrayConverter<Tr2>))]
         public List<Tr2> tr { get; set; }
     }
