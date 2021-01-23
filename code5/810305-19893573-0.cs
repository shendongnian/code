    public class MyData
    {
        [JsonProperty("#type")]
        public string Type { get; set; }
    
        [JsonProperty("#orderNo")]
        public int OrderNo { get; set; 
    
        [JsonProperty("paid")]
        public bool Paid { get; set; }
        [JsonProperty("lines")]
        public List<MyDataLine> Lines { get; set; }
    }
    public class MyDataLines
    {
        [JsonProperty("#type")]
        public string Type { get; set; }
        [JsonProperty("options")]
        public MyDataLinesOptions Options { get; set; }
        // ... more
    }
    public class MyDataLinesOptions
    {
        // ... more
    }
