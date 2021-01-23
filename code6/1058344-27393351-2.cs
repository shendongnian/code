    [XmlType("Question")]
    public class Question
    {
        [XmlElement("Text")]
        public String Text { get;  set; }
        [XmlArray("Answers")]
        public Answer[] Answers { get;  set; }
        [XmlElement("Type")]
        public QuestionType Type { get;  set; }
        [XmlElement("Points")]
        public int Points { get; set; }
        public Question() { }
    }
