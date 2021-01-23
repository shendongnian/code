    public class BookStudent
    {
        [Key, Column(Order = 0)]
        public int BookID { get; set; }
        [Key, Column(Order = 1)]
        public int StudentID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    
        //below two lines will define foreign key
        public Student Student { get; set; }
        public Book Book { get; set; }
    }
    
    
    public class Context : DbContext
    {
        public Context() : base("name=DefaultConnection") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<BookStudent> BookStudents { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove below code
            //modelBuilder.Entity<Book>().HasMany<Student>(t => t.Students).WithMany(t => t.Books).Map(t =>
            //{
            //    t.MapLeftKey("BookId");
            //    t.MapRightKey("StudentId");
            //    t.ToTable("BookStudents");
            //});
        }
    }
