    public class Shelf
    {
        public int ShelfId { get; set; }
        public string ShelfName { get; set; }
        public ShelfType MyProperty { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
