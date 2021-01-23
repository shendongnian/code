    [Serializable()]
    public class SomeClass
    {
        public int Property1 {get; set;}
        
        [NonSerialized()]
        public int Property2 {get; set;}
    }
