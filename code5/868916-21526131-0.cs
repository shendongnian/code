    public class Page
    {
        public List<Paragraph> Paragraphs { get; set; }
    }
    public class Paragraph
    {
        public List<QWord> Sentences { get; set; }
    }
    public class Sentence
    {
        public List<QWord> Words { get; set; }
    }
