    public class Wrapper
    {
        [JsonProperty("retrieval-response")]
        public Result Result { get; set; }
    }
    
    public class Result
    {
        [JsonProperty("cdata")]
        public Data Data { get; set; }
    
        public int Index { get; set; }
    
        public int Count { get; set; }
    }
    
    public class Data
    {
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    
        [JsonProperty("document-count")]
        public string Count { get; set; }
    }
