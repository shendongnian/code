    public class Book
    {
        [Key]
        public Guid Id { get; set; }
    
        public virtual List<Page> Pages { get; set; }
    }
    
    public class Page
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookId { get; set;}
    
        //[ForeignKey("BookId")] you can add the fluent here or during entity builder
        public virtual Book Book { get; set; }
    }
    modelBuilder.Entity<Page>()
        .HasOptional(a => a.Book)
        .WithMany(a=>a.Pages)
        .HasForeignKey(a=>a.BookId)
        .WillCascadeOnDelete(true);
    var pages= dbcontext.Pages.Where(p => p.BookId == book.Id); // this will work
