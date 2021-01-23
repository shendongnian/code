    public IEnumerable<Book> Get()
    {
         
        var client = new MongoClient("mongodb://localhost:27017");
        var server = client.GetServer();
        var db = server.GetDatabase("BookStore");
        var collection = db.GetCollection<Book>("Book");
        Book[] books =
        {
             new Book { Id = 1, Title = "Book Name 1" }, 
             new Book { Id = 2, Title = "Book Name 2" },
             new Book { Id = 3, Title = "Book Name 3" }, 
             new Book { Id = 4, Title = "Book Name 4" }
        };
        foreach (var book in books)
        {
            collection.Save(book);
        }
        return books;
    }
