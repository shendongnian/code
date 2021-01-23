    [Test]
    public void AssignAuthorToBook_NewBookNewAuthor_SuccessfullyAssigned()
    {
      var bookRepositoryMock = new Mock<IBookRepository>(MockBehavior.Loose);
      IBookService service = new BookService(bookRepositoryMock.Object);
      var book = new Book();
      var Author = new Author(); //id does not matter
    
      service.AssignAuthorToBook(book, author);
    
      bookRepositoryMock.Verfify(repo => repo.AssignAuthorToBook(book, author));
    }
