    var obj = JsonConvert.DeserializeObject<Respondents>(jsonResp);
-----
    public class Val
    {
        [JsonConverter(typeof(StringArrayConverter))]
        public List<string> Value { set; get; }
    }
    public class Respondents
    {
        public string ID { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public int Seed { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Duration { get; set; }
        public Dictionary<string,Val> Answers { get; set; }
    }
