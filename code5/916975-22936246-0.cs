    public class MyClass
    {
         public int Id { get; set; }
         [JsonProperty("Logo")]
         public bool HasLogo { get { return Logo != null; } }
         [JsonIgnore]
         public byte[] Logo { get; set; }
    }
