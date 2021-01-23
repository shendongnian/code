    [System.Xml.Serialization.XmlRootAttribute(Namespace = 
      "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd",
       IsNullable = false)]
    public partial class UsernameToken : System.Web.Services.Protocols.SoapHeader
    {
        // Namespace is also available here if different from the root element.
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Username {get; set;}
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Password {get; set;}
    }
