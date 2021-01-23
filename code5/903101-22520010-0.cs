    //in the file where you use JsonConvert
    using Newtonsoft.Json;
    public class item
    {
        public int id { get; set; }
        public int aantal { get; set; }
    }
    
    
    item[] myItems = JsonConvert.Deserialize<item[]>(jsonString);
