    [JsonConverter(typeof(NullStringConverter))]
    public class User
    {
       [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Populate]
       [DefaultValue(string.Empty)] 
       public int Id;
       // The rest of the properties..
    }
