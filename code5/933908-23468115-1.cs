    public class RootObject
    {
        public string body { get; set; }
        public int id { get; set; }
        public string Title { get; set; }
    }
    
    var result = JsonConvert.DeserializeObject<RootObject>(jsonstring);
    result.Title = "Title2";
