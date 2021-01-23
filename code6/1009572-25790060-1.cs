    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ROWDATA
    {
        [System.Xml.Serialization.XmlElementAttribute("ROW")]
        public ROWDATAROW[] ROW { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ROWDATAROW
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ORGCODE { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte BRANCHCODE { get; set; }
    }
