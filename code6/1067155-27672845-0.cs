    [Serializable]
    public class Author
    {
        [XmlAttribute("id")]
        public String Id { get; set; }
        [XmlElement("name")]
        public String Name { get; set; }
    }
    [Serializable]
    public class Book
    {
        private Author _author;
        [XmlIgnore]
        public Author Author
        {
            get { return _author; }
            set
            {
                _author = value;
                AuthorId = _author != null ? _author.Id : null;
            }
        }
        [XmlAttribute("id")]
        public String Id { get; set; }
        [XmlElement("author")]
        public String AuthorId { get; set; }
         [XmlElement("title")]
        public String Title { get; set; }
    }
    [Serializable]
    public class Store
    {
        [XmlArray("authors")]
        [XmlArrayItem("author", Type = typeof(Author))]
        public List<Author> Authors { get; set; }
        [XmlArray("books")]
        [XmlArrayItem("book", Type = typeof(Book))]
        public List<Book> Books { get; set; }
        public Store()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Create some authors
            var authors = new List<Author>
            {
                new Author{Id="PK", Name="Philip Kindred"},
                new Author{Id="WS", Name="William Shakespeare"},
            };
            // Create some books linked to the authors
            var books = new List<Book>
            {
                new Book{Id = "U1", Author = authors[0], Title = "Do Androids Dream of Electric Sheep?"},
                new Book{Id = "U2", Author = authors[1], Title = "Romeo and Juliet"}
            };
           
            var store = new Store {Authors = authors, Books = books};
            var success = Serialiser.SerialiseToXml(store, "store.xml");
            // Deserialize the data from XML
            var store2 = Serialiser.DeserialseFromXml<Store>("store.xml");
            // Resolve the actual Author instances from the saved IDs (foreign key equivalent in databases)
            foreach (var book in store2.Books)
                book.Author = store2.Authors.FirstOrDefault(author => author.Id == book.AuthorId);
            
            // Now variable 'store' and 'store2' have the same equivalent data
        }
    }
    // Helper class to serialize and deserialize the data to XML file
    public static class Serialiser
    {
        public static bool SerialiseToXml(object obj, string filename)
        {
            try
            {
                var ws = new XmlWriterSettings
                {
                    NewLineHandling = NewLineHandling.Entitize,
                    NewLineChars = Environment.NewLine,
                    Indent = true,
                    NewLineOnAttributes = false
                };
                var xs = new XmlSerializer(obj.GetType());
                using (var writer = XmlWriter.Create(filename, ws))
                    xs.Serialize(writer, obj);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static T DeserialseFromXml<T>(string filename) where T : new()
        {
            var typeofT = typeof(T);
            try
            {
                var xs = new XmlSerializer(typeofT);
                using (var reader = XmlReader.Create(filename))
                    return (T)xs.Deserialize(reader);
            }
            catch(Exception ex)
            {
                return default(T);
            }
        }
    }
