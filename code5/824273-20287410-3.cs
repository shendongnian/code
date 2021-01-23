    [XmlRoot(ElementName = "createRequest", Namespace = "http://www.test.com/sign")]
    public class CreateRequest {
      [XmlElement(ElementName="userId", Namespace = "")]
      public string UserId { get; set; }
      [XmlElement(ElementName = "visibleDataContentType", Namespace = "")]
      public string VisibleDataContentType { get; set; }
      [XmlElement(ElementName = "visibleData", Namespace = "")]
      public string VisibleData { get; set; }
      [XmlElement(ElementName = "hiddenData", Namespace = "")]
      public string HiddenData { get; set; }
      [XmlElement(ElementName = "expiryInSeconds", Namespace = "")]
      public int ExpiryInSeconds { get; set; }
    }    
