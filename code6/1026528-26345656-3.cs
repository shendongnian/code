    public class Foo
    {
        [JsonProperty("bar")]         // this will be serialized as "bar"
        public string BarName 
        {
            get { return Bar.Name; }
        }
        [JsonIgnore]                  // this won't be serialized
        public Bar Bar { get; set; }
    }
