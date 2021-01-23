    public DbSet<Parent> Parents { get; set; }
    public DbSet<ContentType> ContentTypes { get; set; }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ContentType>().HasRequired(c => c.Parent).WithMany(p =>p.ContentTypes).HasForeignKey(c => c.ParentId);
        }
