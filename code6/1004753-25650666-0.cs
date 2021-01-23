    [XmlType(TypeName = "MAINOBJECT")]
    public class MainObject
    {
        [XmlElement("DERIVEDCLASS", Type = typeof(DerivedClass))]
        public BaseClass TheBase { get; set; }
    }
