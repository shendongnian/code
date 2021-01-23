    ublic class ParamTable
    {
        public int id { get; set; }
        public int name { get; set; }
        public string code { get; set; }
    }
    
    public class Parameters
    {
        public int id { get; set; }
        public string FilterParam { get; set; }
        public string NameParam { get; set; }
        public List<int> CollectionsIds { get; set; }
        public ParamTable ParamTable { get; set; }
    }
    
    public class RootObject
    {
        public Parameters Parameters { get; set; }
    }
