        internal class Book
        {
            public string Author;
            public string Title;
        }
        List<Book> listOfBooks = new List<Book>()
        {
            new Book() {Author = "author1", Title = "Peter Pan"},
            new Book() {Author = "author2", Title = "The Shining"},
            new Book() {Author = "author2", Title = "IT"},
            new Book() {Author = "author3", Title = "Animal Farm"},
        };
        var author = listOfBooks.GroupBy(x => x.Author)
            .OrderByDescending(g => g.Count())
            .Take(1)
            .Select(g => g.Key);
