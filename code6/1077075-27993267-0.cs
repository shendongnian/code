     [XmlRoot("Library")]
        public class Library
        {
             [XmlElement("Header")]
            public Header header { get; set; }
             [XmlElement("Book")]
            public List<Book> books { get; set; }
             [XmlElement("Author")]
            public List<Author> authors { get; set; }
        }
    
        
        public class Header
        {
              
            public int HeaderID { get; set; }
        }
    
        public class Book
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string Fiction { get; set; }
        }
    
        public class Author
        {
           public  string Name { get; set; }
        }
