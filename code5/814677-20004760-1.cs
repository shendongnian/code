    [XmlInclude(typeof(Class1), XmlInclude(typeof(Class2)), etc]
    public class AbstractBase { }
    public class Class1 : AbstractBase { ... }
    public class Class2 : AbstractBase { ... }
    public class BigClass {
        public SerializableDictionary<string, AbstractBase> Dictionary { get; set; }
    }
