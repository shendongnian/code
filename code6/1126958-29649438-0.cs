    [XmlRoot("recognitionResults")]    
    public class RecognitionResults
    {
        [XmlAttribute("success")]
        public int Success { get; set; }
    
        [XmlElement("variant")]
        public Variant Variant { get; set; }
    }
            
    public class Variant
    {
        [XmlAttribute("confidence")]
        public int Confidence { get; set; }
        
        [XmlText]
        public string Value { get; set; }
    }
