    [Test]
    public void AssignAuthorToBook_NewBookNewAuthor_CreatesNewBookAndAuthorAndAssociatesThem()
    {
      var bookRepositoryMock = new Mock<IBookRepository>(MockBehavior.Loose);
      IBookService service = new BookService(bookRepositoryMock.Object);
      var book = new Book() {Id = 0}
      var author = new Author() {Id = 0}; 
    
      service.AssignAuthorToBook(book, author);
    
      bookRepositoryMock.Verify(repo => repo.AddNewBook(book));
      bookRepositoryMock.Verify(repo => repo.AddNewAuthor(author));
      bookRepositoryMock.Verfify(repo => repo.AssignAuthorToBook(book, author));
    }
