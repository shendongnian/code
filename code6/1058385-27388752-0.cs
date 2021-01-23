    public class DummyClass
    {
        public string Key1 { set; get; }
        public string Key2 { set; get; }
    }
    var dict2 = JsonConvert.DeserializeObject<Dictionary<string,DummyClass>>(DATA);
