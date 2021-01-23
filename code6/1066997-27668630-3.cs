    public class YourContext : DbContext
    {
        public DbSet<BaseCard> BaseCards { get; set; }
        public DbSet<Skill> Skill { get; set; }
       
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure the primary key for the BaseCard
            modelBuilder.Entity<BaseCard>().HasKey(t => t.Id);
            //specify no autogenerate the Id Column
            modelBuilder.Entity<BaseCard>().Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //one-to-many relationship 
            modelBuilder.Entity<Skill>().HasRequired(c => c.BaseCard)
                    .WithMany(s => s.Skills)
                    .HasForeignKey(c => c.BaseCardId);
        }
    }
