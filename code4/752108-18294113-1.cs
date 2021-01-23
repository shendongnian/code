    [XmlRoot(ElementName="array")]
    class JsonToXmlTranslationObject {
         
         [XmlElement(ElementName="item")]
         public int[] item { get; set; }
        
         [XmlAttribute]
         public int length { get; set; }
    }
