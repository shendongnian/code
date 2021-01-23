    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Mary {
        [System.Xml.Serialization.XmlElementAttribute("Frank", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MaryFrank[] Items { get; set; }
    }
    
    [System.SerializableAttribute()]
    public partial class MaryFrank {
        [System.Xml.Serialization.XmlElementAttribute("Joe", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MaryFrankJoe[] Items { get; set; }
    }
    
    [System.SerializableAttribute()]
    public partial class MaryFrankJoe {
        [System.Xml.Serialization.XmlElementAttribute("Susan", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public MaryFrankJoeSusan[] Items { get; set; }
    }
    
    [System.SerializableAttribute()]
    public partial class MaryFrankJoeSusan {
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Stuff { get; set; }
    }
