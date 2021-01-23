    [Serializable]
    [XmlType("Base")]
    [XmlInclude(typeof(InheritedClass1))] //Missing This line! 
    public class Base
    {
         [XmlElement(ElementName = "IdBase")]
         public int IdBase { get; set; }
         ...
    }
