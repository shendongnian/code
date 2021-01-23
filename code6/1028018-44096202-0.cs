    public class Book {
        ...
        public Guid BookId
        ...
        public Guid AuthorId { get; set; }
    
        [ForeignKey("AuthorId")]
        public virtual Author author { get; set; }
    }
    
    public class Author {
        ...
        public Guid AuthorId
        ...
        public Guid? LatestBookId { get; set; }
    
        [ForeignKey("LatestBookId")]
        public virtual Book book { get; set; }
    
        public virtual ICollection<Book> books { get; set; }
    }
    
    // using fluent API
    class BookConfiguration : EntityTypeConfiguration<Book> {
    
        public BookConfiguration() {
            this.HasRequired(b => b.author)
                .WithMany(a => a.books);
        }
    
    }
