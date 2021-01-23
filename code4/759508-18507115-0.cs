    public abstract class MyAbstract
    {
        abstract public MyField {get;set;}
    }
    
    [Serializable]
    public class Class1 : MyAbstract
    {
        [XmlAttribute("MY_FIELD")]
        public MyField {get;set;}
    }
    
    [Serializable]
    public class Class2 : MyAbstract
    {
        [XmlAttribute("my_field")]
        public MyField {get;set;}
    }
