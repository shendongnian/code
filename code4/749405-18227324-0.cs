     public class Schedule
    {
        [JsonProperty("jsonrpc")]
        public string Jsonrpc { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("result")]
        public Dictionary<string, Datas> Result { get; set; }
    }
    public class Datas
    {
        public IEnumerable<string> Notifications { get; set; }
        public IEnumerable<string> Events { get; set; }
        public IEnumerable<string> Lectures { get; set; }
        
    }
