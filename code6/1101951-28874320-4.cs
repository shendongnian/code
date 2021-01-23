    public class Shelf
    {
        public int ShelfId { get; set; }
        public virtual ICollection<BookShelf> BookShelves { get; set; }
        public virtual IQueryable<Book> Books
        {
            get
            {
                return BookShelves.Where(s => s.ShelfId == ShelfId)
                                  .Select(s => s.Book);
            }
        }
    }
    
    public class Book
    {
        public int BookId { get; set; }
        public virtual ICollection<BookShelf> BookShelves { get; set; }
        public virtual IQueryable<Shelf> Shelves
        {
            get
            {
                return BookShelves.Where(s => s.BookId == BookId)
                                  .Select(s => s.Shelf);
            }
        }
    }
    public class BookShelf
    {
        [Key]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Key]
        public int ShelfId { get; set; }
        [ForeignKey("ShelfId")]
        public Shelf Shelf { get; set; }
    }
