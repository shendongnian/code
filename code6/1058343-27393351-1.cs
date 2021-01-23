    [XmlType("Questions")]
    public class QuestionCollection
    {
        [XmlElement("Question")]
        public Question[] Questions { get; set; }
        public QuestionCollection() { }
    }
