    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookGenre { get; set; }
        public DateTime BookPublishedDate { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public int ShelfId { get; set; }
        [ForeignKey("ShelfId")]
        public Shelf Shelf { get; set; }
    }
