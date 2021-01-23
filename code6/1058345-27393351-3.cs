    [XmlType("Answer")]
    public class Answer
    {
        [XmlElement("Text")]
        public String Text { get; set; }
    
        [XmlElement("Correct")]
        public bool Correct { get; set; }
    
        public Answer() { }
    }
