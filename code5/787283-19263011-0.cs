    public class Item
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool can_modify { get; set; }
        public string description { get; set; }
        public string start_date { get; set; }
        public string due_date { get; set; }
        public bool is_active { get; set; }
        public Item parent { get; set; }
        public List<Item> children { get; set; }
    }
    
    public class RootObject
    {
        public List<Item> data { get; set; }
    }
    
    public Dictionary<string, string> ReadJSONProject(string jsObject)
    {
    
        var json = jsObject;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var jsonObject = serializer.Deserialize<RootObject>(json);
        Dictionary<string, string> dic = new Dictionary<string, string>();
    
        foreach (var item in jsonObject.data)
        {
            dic.Add(item.id, item.name);
        }
    
        return dic;
    }
