    public class Author
    {
        public int AuthorId { get; set; }
        public ICollection<Book> Books { get; set; }
        public Book CurrentlyWorkingBook { get; set; }
    }
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public Author EditoredBy { get; set; }
    }
