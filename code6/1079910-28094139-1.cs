    db.Books.Where(book => book.Author.Active && book.Author.ShowOnBookWall)
        .Select(book => new BooksViewModel
        {
            BookId = book.Id,
            AuthorId = book.Author.Id,
            AuthorName = book.Author.Name,
            BookName = book.Name
        })
