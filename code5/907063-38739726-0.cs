    [JsonObject(MemberSerialization.OptIn)]
    public class File
    {
      // excluded from serialization
      // does not have JsonPropertyAttribute
      public Guid Id { get; set; }
      [JsonProperty]
      public string Name { get; set; }
      [JsonProperty]
      public int Size { get; set; }
    }
