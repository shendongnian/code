    public class Function
    {
        public string State { get; set; }
    }
    
    public class Datum
    {
        public string CardName { get; set; }
        public List<Function> functions { get; set; }
    }
    
    public class Root
    {
        public List<Datum> data { get; set; }
    }
    
    public class RootObject
    {
        public Root Root { get; set; }
    }
