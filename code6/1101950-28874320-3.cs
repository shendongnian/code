    public class Shelf
    {
        public int ShelfId { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    
    public class Book
    {
        public int BookId { get; set; }
        public virtual ICollection<Shelf> Shelves { get; set; }
    }
