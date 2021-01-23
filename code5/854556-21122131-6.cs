    public class JoinClass
    {
        private Book _Book;
        private LibraryStock _LibraryStock;
        public Book GetBook() { return _Book; }
        public LibraryStock GetLibraryStock() { return _LibraryStock; }
        public JoinClass()
        {
            _LibraryStock = new LibraryStock();
            _Book = new Book();
            _LibraryStock.Book = _Book;
        }
        public JoinClass(LibraryStock libraryStock)
        {
            _LibraryStock = libraryStock;
            _Book = libraryStock.Book;
        }
     // here properties of both entities
    }
