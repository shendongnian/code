    var obj = JsonConvert.DeserializeObject<RootObject>(json); //Json.Net
    //or
    //var obj = new JavaScriptSerializer().Deserialize<RootObject>(json);
    public class Content
    {
        public string type { get; set; }
        public int total { get; set; }
        public int scan { get; set; }
        public Dictionary<string,List<List<string>>> tips { get; set; }
        public bool success { get; set; }
        public List<object> errors { get; set; }
    }
    public class RootObject
    {
        public Content content { get; set; }
    }
