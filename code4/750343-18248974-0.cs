    public class CategoryList
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    
    public class Datum
    {
        public string category { get; set; }
        public List<CategoryList> category_list { get; set; }
        public string name { get; set; }
        public string created_time { get; set; }
        public string id { get; set; }
    }
    
    public class Paging
    {
        public string next { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
        public Paging paging { get; set; }
    }
---
    
    var obj = JsonConvert.DeserializeObject<RootObject>(json);
