    public class Data1 : IData
    {
        public String Name { get; set; }
    }
    
    public class Data2 : ISettableData
    {
        public String Name { set; }
    }
