    public class ItemClass
    {
        public int ID { get; set; }
    
        public string Name { get; set; }
    
        public string Prop1 { get; set; }
    
        public string Prop2 { get; set; }
    }
    public class Connection
    {
        // ...
    
        public ConnectionType Type { get; set; }
    
        public ItemClass Source { get; set; }
    
        public ItemClass Target { get; set; }
    
        // ...
    }
