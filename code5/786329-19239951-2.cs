    var Obj = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject[]>(jsonString);
    public class Sublist
    {
        public string sub_id { get; set; }
        public string sub_name { get; set; }
    }
    
    public class Category
    {
        public string cat_id { get; set; }
        public string cat_name { get; set; }
        public string chk_value { get; set; }
        public List<Sublist> sublist { get; set; }
    }
    
    public class Catlist
    {
        public string area_id { get; set; }
        public string area_name { get; set; }
        public List<Category> categories { get; set; }
    }
    
    public class RootObject
    {
        public List<Catlist> catlist { get; set; }
    }
