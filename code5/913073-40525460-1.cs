    public class Book
        {
            [Key]
            public int BookId { get; set; }
            [Required]
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Genre { get; set; }
            public DateTime PublishDate { get; set; }
            public string Description { get; set; }
            public int AuthorID { get; set; }
            [ForeignKey("AuthorID")]
            public virtual Author Author { get; set; }
        }
