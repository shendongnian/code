    [XmlRoot("books")]
    public class BookRoot {
        private readonly List<Book> books = new List<Book>();
        [XmlElement("book")]
        public List<Book> Books { get { return books; } }
    }
    public class Book {
        [XmlAttribute("label")]
        public string Label {get;set;}
        [XmlAttribute("page")]
        public string Page {get;set;}
        [XmlAttribute("intro")]
        public string Intro {get;set;}
    }
