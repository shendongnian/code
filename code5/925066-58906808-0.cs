    public class Data
    {
        public string Name { get; set; }
        [JsonPropertyName(".net version")]
        public string DotNetVersion { get; set; }
        [JsonPropertyName("binding type")]
        public string BindingType { get; set; }
    }
    
    // to deserialize
    var data = JsonSerializer.Deserialize<Data>(json);
