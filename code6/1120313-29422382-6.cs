    public class TeamDBContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                        .HasRequired(p => p.Team)
                        .WithMany(t => t.Players)
                        .HasForeignKey(p => p.TeamId)
        }
    }
