    public class ApplicationUser : IdentityUser
    {
        public int ContactId { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; } 
    }
