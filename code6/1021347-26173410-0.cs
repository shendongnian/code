    public class Book
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; }
        public int? SeriesID { get; set; }
        public int GenreID { get; set; }
        [ForeignKey("GenreID")]
        public virtual Genre Genre { get; set; }
        etc
    }
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
