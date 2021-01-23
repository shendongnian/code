        public class TestContext : DbContext
        {
            public DbSet<employee> Employees { get; set; }
            protected override void OnModelCreating(DbModelBuilder mb)
            {
                mb.Entity<employee>()
                    .Property(i => i.fName)
                    .HasColumnType("char")
                    .HasMaxLength(20);
                base.OnModelCreating(mb);
            }
        }
