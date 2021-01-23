    public class Course
    {
        public int Id { get; set; }
        public string CouresNumber { get; set; }
        public virtual ICollection<PreqEdge> Parents { get; set; }
        public virtual ICollection<PreqEdge> Children { get; set; }
    }
    public class PreqEdge
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public virtual Course Parent { get; set; }
        public virtual Course Child { get; set; }
    }
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<PreqEdge> PreqEdges { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PreqEdge>()
                        .HasRequired(e => e.Parent)
                        .WithMany(c => c.Parents)
                        .HasForeignKey(e => e.ParentId)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<PreqEdge>()
                        .HasRequired(e => e.Child)
                        .WithMany(c => c.Children)
                        .HasForeignKey(e => e.ChildId)
                        .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
