    public class CompositeKey 
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
    }  
    public class A 
    {
        public CompositeKey Key { get; set; }
        public int Prop3 { get; set; }
        public int Prop4 { get; set; }
    }
    ...
