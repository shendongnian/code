    public class Book {
        public Author Author { get; set; }
        public int AuthorId { 
            get { return Author.ID; }
            set { Author.ID = value; }
        }
    }
    
    public class Author {
        public int Id { get; set; }
    }
    public class BookService {
        public void AssignAuthorToBook(Book book, Author author)
        {
            book.Author = author;
        }
    }
