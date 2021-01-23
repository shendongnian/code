    // at first
    public interface IHasProperty
    {
        string prop1 {get; set;}
    }
    
    public class SerializableClass: IHasProperty
    {
        public string prop1 {get; set;}
    }
    
    // but then you change SerializableClass
    public class SerializableClass: IHasProperty
    {
        public string prop1 {get; set;}
        public string prop2 {get; private set;} // oops
    }
