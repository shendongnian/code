    public class Author
    {
        string id;
        Store store;
        [XmlIgnore]
        public Store Store {
            get {
                return store;
            }
            set {
                if (store != null && id != null)
                    store.Authors.Remove(id);
                this.store = value;
                if (store != null && id != null)
                    store.Authors[id] = this;
            }
        }
        [XmlAttribute("id")]
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (store != null && id != null)
                    store.Authors.Remove(id);
                this.id = value;
                if (store != null && id != null)
                    store.Authors[id] = this;
            }
        }
        [XmlElement("name")]
        public string Name { get; set; }
    }
    public class Book
    {
        string authorId;
        string id;
        Store store;
        [XmlIgnore]
        public Store Store
        {
            get
            {
                return store;
            }
            set
            {
                if (store != null && id != null)
                    store.Books.Remove(id);
                this.store = value;
                if (store != null && id != null)
                    store.Books[id] = this;
            }
        }
        [XmlAttribute("id")]
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (store != null && id != null)
                    store.Books.Remove(id);
                this.id = value;
                if (store != null && id != null)
                    store.Books[id] = this;
            }
        }
        [XmlElement("author")]
        public string AuthorID
        {
            get
            {
                return authorId;
            }
            set
            {
                authorId = value;
            }
        }
        [XmlIgnore]
        public Author Author
        {
            get
            {
                if (store == null)
                    return null;
                if (AuthorID == null)
                    return null;
                return store.Authors[AuthorID];
            }
            set
            {
                if (value == Author)
                    return;
                if (value == null)
                {
                    authorId = null;
                }
                else
                {
                    if (value.Id == null)
                        throw new ArgumentException();
                    authorId = value.Id;
                }
                AssertCorrectAuthor(value);
            }
        }
        
        [Conditional("DEBUG")]
        private void AssertCorrectAuthor(Author author)
        {
            if (store != null)
                Debug.Assert(author == Author);
        }
        [XmlElement("title")]
        public string Title { get; set; }
    }
    [XmlRoot("store")]
    public class Store
    {
        readonly Dictionary<string, Book> books = new Dictionary<string, Book>();
        readonly Dictionary<string, Author> authors = new Dictionary<string, Author>();
        [XmlIgnore]
        public IDictionary<string, Book> Books
        {
            get
            {
                return books;
            }
        }
        [XmlIgnore]
        public IDictionary<string, Author> Authors
        {
            get
            {
                return authors;
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("authors")]
        [XmlArrayItem("author")]
        public Author[] AuthorList // proxy array for serialization.
        {
            get
            {
                return Authors.Values.ToArray();
            }
            set
            {
                foreach (var author in authors.Values)
                {
                    author.Store = null;
                }
                Authors.Clear();
                if (value == null)
                    return;
                foreach (var author in value)
                {
                    author.Store = this;
                }
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [XmlArray("books")]
        [XmlArrayItem("book")]
        public Book[] BookList // proxy array for serialization.
        {
            get
            {
                return Books.Values.ToArray();
            }
            set
            {
                foreach (var book in Books.Values)
                {
                    book.Store = null;
                }
                Books.Clear();
                if (value == null)
                    return;
                foreach (var book in value)
                {
                    book.Store = this;
                }
            }
        }
    }
