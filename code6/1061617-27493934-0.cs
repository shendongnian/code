    public class ModelRoot
    {
        public string Version { set; get; }
        public List<Dictionary<string,ModelValue>> values { set; get; }
        // This would work too
        //public List<Dictionary<DateTime,ModelValue>> values { set; get; }
    }
    public class ModelValue
    {
        public string Energy { set; get; }
        public string Temp { set; get; }
    }
---
    var obj = JsonConvert.DeserializeObject<ModelRoot>(json);
