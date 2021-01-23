    public class recipients
    {
        [System.Xml.Serialization.XmlElementAttribute("gsm", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        public List<gsm> gsm{ get; set; }
        public recipients()
        {
            gsm = new List<gsm>();
        }
    }
