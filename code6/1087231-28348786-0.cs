    using(WebClient wc = new WebClient())
    {
        var url = "...";
        var json = wc.DownloadString(url);
        Result result = JsonConvert.DeserializeObject<Result>(json);
        // result.Values should contain the Test instances at this point.
    }
    
    public class Result
    {
        [JsonProperty("success")]
        public string Success { get; set; }
        [JsonProperty("TEST")]
        public Dictionary<string,Test> Tests{ get; set; }
    }
    public class Test
    {
    // omitted - same as in question.
    }
