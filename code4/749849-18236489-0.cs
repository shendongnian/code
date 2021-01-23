    [Test]
    public void AssignAuthorToBook_NewBookNewAuthor_SuccessfullyAssigned()
    {
      IBookService service = new BookService();
    
      var book = new Book();
      var bookID = 122;
      book.ID = bookId;
      var Author = new Author() { Id = 123 };
    
      service.AssignAuthorToBook(book, author);
    
    //ask the service for the book, which uses EF to get the book and populate the navigational properties, etc...
      book = service.GetBook(bookID)
    
      Assert.AreEqual(book.AuthorId, 123);
    }
