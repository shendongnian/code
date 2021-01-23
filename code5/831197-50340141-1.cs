    enter public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        BooksEntities ctx = new BooksEntities();
        List<Author> _authors;
        List<Book> _books;
        Author _selectedAuthor;
        Book _selectedBook;
        public MainViewModel()
        {
            FillAuthors();
        }
        public List<Author> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                NotifyPropertyChanged();
                if (_authors.Count > 0) SelectedAuthor = _authors[0]; // <--- DO THIS
            }
        }
        public Author SelectedAuthor
        {
            get { return _selectedAuthor; }
            set
            {
                _selectedAuthor = value;
                FillBooks();
                NotifyPropertyChanged();
            }
        }
        public List<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                NotifyPropertyChanged();
                if (_books.Count > 0) SelectedBook = _books[0]; // <--- DO THIS
            }
        }
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                NotifyPropertyChanged();
            }
        }
        #region Private Functions
        private void FillAuthors()
        {
            var q = (from a in ctx.Authors select a).ToList();
            this.Authors = q;
        }
        private void FillBooks()
        {
            Author author = this.SelectedAuthor;
            var q = (from b in ctx.Books
                     orderby b.BookTitle
                     where b.AuthorId == author.Id
                     select b).ToList();
            this.Books = q;
        }
        #endregion
    }
