    public static List<Book> GetBooks()
    {
        XDocument document = XDocument.Load(xmlFile);
    
        var query = from t in document.Root.Elements("book")
                    select new Book()
                    {
                        Author = t.Element("author").Value,
                        Title = t.Element("title").Value
                    };
    
        return query.ToList();
    }
