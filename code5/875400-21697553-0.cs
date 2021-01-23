    var obj = JsonConvert.DeserializeObject<RootClass>(json);
    public class RootClass
    {
        public int Success { set; get; }
        public Dictionary<string, Data> Return { set; get; }
    }
    public class Data
    {
        public decimal Amount { set; get; }
        public decimal Rate { set; get; }
    }
