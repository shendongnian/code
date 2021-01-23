    public class MyEntities : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Match>().HasOptional(x => x.HomeTeam).WithMany().Map(m => m.MapKey("HomeTeamId"));
            modelBuilder.Entity<Match>().HasOptional(x => x.AwayTeam).WithMany().Map(m => m.MapKey("AwayTeamId"));
        }
    }
