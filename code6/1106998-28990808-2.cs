    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    [XmlRootAttribute(ElementName = "error", Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", IsNullable = false)]
    public partial class ODATAException
    {
      public string code { get; set; }
      public ODATAErrorMessage message { get; set; }
      public ODATAInternalException innererror { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public partial class ODATAErrorMessage
    {
      [XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
      public string lang { get; set; }
      [XmlTextAttribute()]
      public string Value { get; set; }
    }
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public partial class ODATAInternalException
    {
      public string message { get; set; }
      public string type { get; set; }
      public string stacktrace { get; set; }
      public ODATAInternalException internalexception { get; set; }
    }
