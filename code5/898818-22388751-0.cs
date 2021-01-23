    public class Data
    {
        public Dictionary<string, Node> data { get; set; }
    }
    
    public class Node
    {
        public string name { get; set; }
    }
    var result = JsonConvert.DeserializeObject<Data>(json);
