    public class MyObj
    {
        [JsonProperty(PropertyName = "Question")
        public string Question { get; set; }
        [JsonProperty(PropertyName = "Answer")]
        public string Answer { get; set; }
    }
